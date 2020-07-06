using System;
using System.Collections.Generic;
using System.Text;

namespace SKY.Domain.Models
{
	public class InserirUsuarioModel
	{
		public InserirUsuarioModel()
		{ 
			
		}

		public InserirUsuarioModel(string nome, string email, string senha, List<InserirTelefoneModel> telefones)
		{
			this.nome = nome;
			this.email = email;
			this.senha = senha;
			this.telefones = telefones;
		}

		public string nome { get; set; }
		public string email { get; set; }
		public string senha { get; set; }
		public List<InserirTelefoneModel> telefones { get; set; }
	}
}
