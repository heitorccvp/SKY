using System;
using System.Collections.Generic;
using System.Text;

namespace SKY.Domain.Models
{
	public class AlterarTelefoneModel
	{
		public AlterarTelefoneModel() 
		{
			
		}

		public AlterarTelefoneModel(int id, string ddd, string numero)
		{
			this.id = id;
			this.ddd = ddd;
			this.numero = numero;
		}

		public int id { get; set; }
		public string ddd { get; set; }
		public string numero { get; set; }

	}
}
