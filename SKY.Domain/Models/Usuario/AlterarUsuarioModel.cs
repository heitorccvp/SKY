using System;
using System.Collections.Generic;
using System.Text;

namespace SKY.Domain.Models
{
	public class AlterarUsuarioModel
	{

		public AlterarUsuarioModel()
		{ 
		
		}

		public AlterarUsuarioModel(Guid id, string nome, string email, string senha, List<TelefoneModel> telefones)
		{
			this.id = id;
			this.nome = nome;
			this.email = email;
			this.senha = senha;
			this.telefones = telefones;
		}

		public Guid id { get; set; }
		public string nome { get; set; }
		public string email { get; set; }
		public string senha { get; set; }
		public List<TelefoneModel> telefones { get; set; }
	}
}
