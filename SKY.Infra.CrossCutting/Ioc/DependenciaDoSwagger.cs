using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace SKY.Infra.CrossCutting.Ioc
{
	public static class DependenciaDoSwagger
	{
		public static void AdicionandoSwagger(this IServiceCollection service)
		{

			service.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
				{
					Version = "v1",
					Title = "Api Sing up/Sign in",
					Description = "API Teste SKY Sing"
				});
			});

		}

		public static void ConfigurandoSwagger(this IApplicationBuilder aplicacao)
		{

			aplicacao.UseSwagger();
			aplicacao.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1 SKY");
			});

		}


	}
}
