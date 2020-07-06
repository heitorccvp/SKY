using System;

namespace SKY.Domain.Entities
{
	public class Telefone
	{

		public Telefone(Guid id, string ddd, string numero)
		{
			this.id = id;
			this.ddd = ddd;
			this.numero = numero;
		}

		public Guid id { get; set; }
		public string ddd { get; set; }
		public string numero { get; set; }

	}
}
