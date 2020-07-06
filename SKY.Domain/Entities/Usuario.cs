using System;
using System.Collections.Generic;

namespace SKY.Domain.Entities
{

	public class Usuario
    {

        public Usuario(Guid id, string nome, string email, string senha, List<Telefone> telefones)
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
        public List<Telefone> telefones { get; set; }

        public DateTime? data_criacao { get; set; }

        public DateTime? data_atualizacao { get; set; }

        public DateTime? ultimo_login { get; set; }

        public string token { get; set; }

    }

}
