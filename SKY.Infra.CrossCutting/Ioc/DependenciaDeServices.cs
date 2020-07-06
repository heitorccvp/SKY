using Microsoft.Extensions.DependencyInjection;
using SKY.Domain.Interfaces;
using SKY.Service.Services;

namespace SKY.Infra.CrossCutting.Ioc
{
	public static class DependenciaDeServices
	{
		public static void AdicionandoDependeciaDeServicos(this IServiceCollection servico)
		{
			servico.AddScoped<IUsuarioService, UsuarioService>();
		}

	}
}
