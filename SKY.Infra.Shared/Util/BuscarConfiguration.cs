using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SKY.Infra.Shared.Util
{
	public static class BuscarConfiguration
	{
		public static string BuscarChaveDoConfigDeOrigem(string chave)
		{
			try
			{
				IConfigurationBuilder builder = new ConfigurationBuilder();
				builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));

				var root = builder.Build();
				var srtConn = root.GetSection(chave);
				return srtConn.Value;
			}
			catch (Exception ex)
			{
				return null;
			}

		}
	}
}
