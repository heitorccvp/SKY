using System;
using System.Collections.Generic;
using System.Text;

namespace SKY.Domain.Models
{
	public class TelefoneModel
	{
		public TelefoneModel()
		{ 
		
		}

		public TelefoneModel(Guid id, string numero, string ddd)
		{
			this.id = id;
			this.numero = numero;
			this.ddd = ddd;
		}

		public Guid id { get; set; }
		public string numero { get; set; }
		public string ddd { get; set; }
	}
}
