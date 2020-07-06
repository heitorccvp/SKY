using System;
using System.Collections.Generic;
using System.Text;

namespace SKY.Domain.Models
{
	public class InserirTelefoneModel
	{
		public InserirTelefoneModel()
		{ 
		
		}

		public InserirTelefoneModel(string numero, string ddd)
		{
			this.numero = numero;
			this.ddd = ddd;
		}

		public string numero { get; set; }
		public string ddd { get; set; }
	}
}
