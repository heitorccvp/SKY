using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using System.Threading.Tasks;

namespace SKY.Infra.CrossCutting.Ioc
{
	public static class DependenciaJWT
	{
		public static void AdicionandoJTW(this IServiceCollection service, IConfiguration Configuration)
		{
            service.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       ValidateIssuerSigningKey = true,
                       ValidIssuer = Configuration["UrlApiSky"],
                       ValidAudience = Configuration["UrlSiteSky"],
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SecurityKey"]))
                   };

                   options.Events = new JwtBearerEvents
                   {

                       OnAuthenticationFailed = context => {
                           Console.WriteLine("Token invalido: " + context.Exception.Message);
                           return Task.CompletedTask;
                       },
                       OnTokenValidated = context => {

                           Console.WriteLine("Token valido: " + context.SecurityToken);
                           return Task.CompletedTask;
                       }
                   };


               });

        }


    }
}
