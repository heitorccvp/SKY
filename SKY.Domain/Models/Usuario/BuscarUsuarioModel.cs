using System;
using System.Collections.Generic;
using System.Net.Cache;
using System.Text;

namespace SKY.Domain.Models
{
	public class BuscarUsuarioModel
	{

		public BuscarUsuarioModel()
		{
			
		}

		public Guid id { get; set; }

		public string nome { get; set; }

		public string email { get; set; }
	}
}
