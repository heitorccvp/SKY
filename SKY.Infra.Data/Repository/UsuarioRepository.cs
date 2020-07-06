using Newtonsoft.Json;
using SKY.Domain.Entities;
using SKY.Domain.Interfaces.Repository;
using SKY.Infra.Data.Context;
using SKY.Infra.Shared.Util;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;


namespace SKY.Infra.Data.Repository
{
	public class UsuarioRepository : IUsuarioRepository
	{
		private readonly string colecaoUsuarios = "usuarios";
		public Usuario Alterar(Usuario alterarUsuarioModel)
		{
			AtualizarFireBase(alterarUsuarioModel);

			return alterarUsuarioModel;
		}

		public async void AtualizarFireBase(Usuario alterarUsuarioModel)
		{
			FirestoreDbContext firestoreDbContext = new FirestoreDbContext();

			await firestoreDbContext.AlterarColecaoUsuario(colecaoUsuarios, alterarUsuarioModel);
		}


		public IEnumerable<Usuario> BuscarTodos()
		{
			throw new NotImplementedException();
		}

		public Usuario BuscarUsuario(string email)
		{
			FirestoreDbContext firestoreDbContext = new FirestoreDbContext();

			var retorno = firestoreDbContext.LerColecaoPorEmail(colecaoUsuarios, email);

			//var usuario = JsonConvert.DeserializeObject<Usuario>(retorno.ToString());

			return retorno.Result;
		}

		public int Excluir(Guid id)
		{
			throw new NotImplementedException();
		}

		public Usuario Inserir(Usuario inserirUsuario)
		{
			FirestoreDbContext firestoreDbContext = new FirestoreDbContext();

			inserirUsuario.token = GerarToken.GerarJwt(inserirUsuario).ToString();
			inserirUsuario.data_criacao = DateTime.Now;
			inserirUsuario.data_atualizacao = DateTime.Now;
			inserirUsuario.senha = inserirUsuario.senha.RetornarHash();

			Dictionary<string, object> user = new Dictionary<string, object> {
					{"id" , inserirUsuario.id.ToString()},
					{"nome", inserirUsuario.nome},
					{"email", inserirUsuario.email},
					{"senha", inserirUsuario.senha},
					{"data_criacao", inserirUsuario.data_criacao.HasValue ? inserirUsuario.data_criacao.ToString() : string.Empty},
					{"data_atualizacao", inserirUsuario.data_atualizacao.HasValue ? inserirUsuario.data_atualizacao.ToString() : string.Empty},
					{"ultimo_login", inserirUsuario.ultimo_login.HasValue ? inserirUsuario.ultimo_login.ToString() : string.Empty},
					{"token", inserirUsuario.token},
					{"telefones", Convercoes.converterParaJson(inserirUsuario.telefones)}
			};

			try
			{
				firestoreDbContext.AdicionarUmaColecao(colecaoUsuarios, user);

				return inserirUsuario;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message); 
			}
		}


	}
}
