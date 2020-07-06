using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SKY.Domain.Models
{
	public class UsuarioModel
	{
		public UsuarioModel()
		{ 
		
		}

		public UsuarioModel(Guid id, string nome, string email, List<TelefoneModel> telefones, string token) 
		{
			this.id = id;
			this.nome = nome;
			this.email = email;
			this.telefones = telefones;
			this.token = token;
		}

		public Guid id { get; set; }
		public string nome { get; set; }
		public string email { get; set; }
		public List<TelefoneModel> telefones { get; set; }

		public string token { get; set; }

	}
}
