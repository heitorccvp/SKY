using Microsoft.VisualStudio.TestTools.UnitTesting;
using SKY.Infra.Data.Context;
using System.Collections.Generic;
using System.Threading.Tasks;
using SKY.Infra.Shared.Util;
using SKY.Domain.Entities;
using System;
using SKY.Infra.Data.Repository;
using Newtonsoft.Json;

namespace SKY.UnitTest
{
	[TestClass]
	public class UnitTestMain
	{
		[TestMethod]
		public void TestDbFireBase()
		{
			FirestoreDbContext firestoreDbContext = new FirestoreDbContext();

			string colecaoUsuarios = "usuarios";

			Telefone telefone = new Telefone(Guid.NewGuid(), "11", "123456789");
			Telefone telefone2 = new Telefone(Guid.NewGuid(), "12", "987465321");
			List<Telefone> telefones = new List<Telefone>();
			telefones.Add(telefone);
			telefones.Add(telefone2);

			Usuario usuario = new Usuario(Guid.NewGuid(), "Heitor2", "heitorTeste2@gmail.com", "123456789", telefones);
			usuario.data_criacao = DateTime.Now;
			usuario.data_atualizacao = DateTime.Now;
			usuario.senha = usuario.senha.RetornarHash();
			usuario.ultimo_login = DateTime.Now;

			Dictionary<string, object> user = new Dictionary<string, object> {
					{"id" , usuario.id.ToString()},
					{"nome", usuario.nome},
					{"email", usuario.email},
					{"senha", usuario.senha},
					{"data_criacao", usuario.data_criacao.HasValue ? usuario.data_criacao.ToString() : string.Empty},
					{"data_atualizacao", usuario.data_atualizacao.HasValue ? usuario.data_atualizacao.ToString() : string.Empty},
					{"ultimo_login", usuario.ultimo_login.HasValue ? usuario.ultimo_login.ToString() : string.Empty},
					{"token", string.Empty },
					{"telefones", Convercoes.converterParaJson(usuario.telefones)}
			};

			firestoreDbContext.AdicionarUmaColecao(colecaoUsuarios, user);

		}


		[TestMethod]
		public async Task LerUmDocumentoNoFirebase()
		{
			FirestoreDbContext firestoreDbContext = new FirestoreDbContext();
			string colecaoUsuarios = "usuarios";
			var retorno = await firestoreDbContext.LerColecaoPorEmail(colecaoUsuarios, "heitorTeste2@gmail.com");

			var teste = JsonConvert.DeserializeObject<Usuario>(retorno.ToString());
		}

		[TestMethod]
		public async Task LerUmaColecaoNoFirebase()
		{
			FirestoreDbContext firestoreDbContext = new FirestoreDbContext();
			string colecaoUsuarios = "usuarios";
			var retorno = await firestoreDbContext.LerColecaoInteira(colecaoUsuarios);
		}


		[TestMethod]
		public async Task AlterarColecaoUsuario()
		{
			FirestoreDbContext firestoreDbContext = new FirestoreDbContext();

			string colecaoUsuarios = "usuarios";

			Telefone telefone = new Telefone(Guid.NewGuid(), "11", "123456789");
			Telefone telefone2 = new Telefone(Guid.NewGuid(), "12", "987465321");
			List<Telefone> telefones = new List<Telefone>();
			telefones.Add(telefone);
			telefones.Add(telefone2);

			Usuario usuario = new Usuario(Guid.NewGuid(), "Suelen3333333", "suelen5@gmail.com", "123456789", telefones);
			usuario.data_criacao = DateTime.Now;
			usuario.data_atualizacao = DateTime.Now;
			usuario.senha = usuario.senha.RetornarHash();
			usuario.ultimo_login = DateTime.Now;

			await firestoreDbContext.AlterarColecaoUsuario(colecaoUsuarios, usuario);

		}



	}
}
