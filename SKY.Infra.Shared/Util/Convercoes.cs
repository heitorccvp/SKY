using Newtonsoft.Json;
using SKY.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SKY.Infra.Shared.Util
{
	public static class Convercoes
	{
		public static Dictionary<string, object> converterDicionario(this object obj)
		{
			var json = JsonConvert.SerializeObject(obj);
			var dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);

			return dictionary;
		}

		public static Usuario converterDicionarioParaObjeto(this Dictionary<string, object> dicionario)
		{
			var json = JsonConvert.SerializeObject(dicionario, Newtonsoft.Json.Formatting.Indented);
			return JsonConvert.DeserializeObject<Usuario>(json.Replace("\\", "").Replace("\"[", "[").Replace("]\"", "]"));
		}

		public static string converterParaJson(object lista)
		{
			return JsonConvert.SerializeObject(lista);
		}

	}
}
