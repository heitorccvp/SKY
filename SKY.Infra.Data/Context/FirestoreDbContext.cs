using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using Grpc.Auth;
using Grpc.Core;
using Newtonsoft.Json;
using SKY.Domain.Entities;
using SKY.Infra.Shared.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace SKY.Infra.Data.Context
{
	public class FirestoreDbContext
	{
		private readonly string projectId = "skyteste-9ba14";
		private FirestoreDb db;

		public FirestoreDbContext()
		{
			AuthExplicit();
		}

		public void AuthExplicit()
		{
			string caminho = Path.Combine(Directory.GetCurrentDirectory(), "skyteste-29c0288e6c0e.json");

			GoogleCredential cred = GoogleCredential.FromFile(caminho);
			
			Channel channel = new Channel(FirestoreClient.DefaultEndpoint.Host,
						  FirestoreClient.DefaultEndpoint.Port,
						  cred.ToChannelCredentials());

			FirestoreClient client = FirestoreClient.Create(channel);
			db = FirestoreDb.Create(projectId, client);
		}

		public async Task AdicionarUmaColecao(string colecao, Dictionary<string, object> dicionario)
		{
			object email = string.Empty;

			dicionario.TryGetValue("email", out email);

			var registro = await LerColecaoPorEmail(colecao, Convert.ToString(email));

			if (registro != null)
			{
				throw new Exception("E-mail já existente");
			}
			else
			{
				DocumentReference docRef = db.Collection(colecao).Document();

				try
				{
					docRef.SetAsync(dicionario);
				}
				catch (Exception ex)
				{
					Debug.WriteLine(ex.Message);
					throw new Exception("Erro: " + ex.Message);
				}
			}
		}

		public async Task AlterarColecaoUsuario(string colecao, Usuario usuario)
		{
			CollectionReference usersRef = db.Collection(colecao);
			Query query = usersRef.WhereEqualTo("email", usuario.email);
			QuerySnapshot snapshot = await query.GetSnapshotAsync();

			var idFireBase = snapshot.Documents.FirstOrDefault().Id;

			DocumentReference usuarioRef = db.Collection(colecao).Document(idFireBase.ToString());

			await db.RunTransactionAsync(async transaction =>
			{
				DocumentSnapshot snapshot = await transaction.GetSnapshotAsync(usuarioRef);

				Dictionary<string, object> updates = new Dictionary<string, object> {
					{"id" , usuario.id.ToString()},
					{"nome", usuario.nome},
					{"email", usuario.email},
					{"senha", usuario.senha},
					{"data_criacao", usuario.data_criacao.HasValue ? usuario.data_criacao.ToString() : string.Empty},
					{"data_atualizacao", usuario.data_atualizacao.HasValue ? usuario.data_atualizacao.ToString() : string.Empty},
					{"ultimo_login", usuario.ultimo_login.HasValue ? usuario.ultimo_login.ToString() : string.Empty},
					{"token", usuario.token},
					{"telefones", Convercoes.converterParaJson(usuario.telefones)}
			};

				transaction.Update(usuarioRef, updates);
			});
		}

		public async Task<Usuario> LerColecaoPorEmail(string colecao, string email)
		{
			CollectionReference usersRef = db.Collection(colecao);
			Query query = usersRef.WhereEqualTo("email", email);

			try
			{
				QuerySnapshot snapshot = await query.GetSnapshotAsync();

				Usuario retorno = null;

				if (snapshot.Count > 0)
					retorno = snapshot.Documents.FirstOrDefault().ToDictionary().converterDicionarioParaObjeto();

				return retorno;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<Usuario> LerColecaoPorId(string colecao, Guid id)
		{
			CollectionReference usersRef = db.Collection(colecao);
			Query query = usersRef.WhereEqualTo("id", id);

			try
			{
				QuerySnapshot snapshot = await query.GetSnapshotAsync();

				Usuario retorno = null;

				if (snapshot.Count > 0)
					retorno = snapshot.Documents.FirstOrDefault().ToDictionary().converterDicionarioParaObjeto();

				return retorno;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}


		public async Task<List<object>> LerColecaoInteira(string colecao)
		{
			CollectionReference usersRef = db.Collection(colecao);
			QuerySnapshot snapshot = await usersRef.GetSnapshotAsync();

			List<object> retorno = new List<object>();

			foreach (DocumentSnapshot document in snapshot.Documents)
			{
				Dictionary<string, object> documentDictionary = document.ToDictionary();

				var doc = documentDictionary.converterDicionarioParaObjeto();

				retorno.Add(doc);
			}

			return retorno;
		}


	}
}
