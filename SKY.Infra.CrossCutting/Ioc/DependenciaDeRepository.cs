using Microsoft.Extensions.DependencyInjection;
using SKY.Domain.Interfaces.Repository;
using SKY.Infra.Data.Repository;

namespace SKY.Infra.CrossCutting.Ioc
{
	public static class DependenciaDeRepository
	{
		public static void AdicionandoOsRepositorios(this IServiceCollection service)
		{
			service.AddScoped<IUsuarioRepository, UsuarioRepository>();
		}
	}
}
