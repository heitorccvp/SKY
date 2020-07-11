using Microsoft.IdentityModel.Tokens;
using SKY.Domain.Entities;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SKY.Infra.Shared.Util
{
	public static class GerarToken
	{
        public static string GerarJwt(Usuario request)
        {
            string role = "Usuario";

            var atributos = new[] {
                new Claim(ClaimTypes.Name, request.nome),
                new Claim(ClaimTypes.Role, role)
            };

            var nossaChave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("gg%88*599qweasdzxcvb^!$$vbnvbn12"));

            //var emissorDoToken = "http://localhost:2982/";
            //var destinatarioQueVaiUsar = "http://localhost:2982/";
            var tempoDeExpiracaoToken = DateTime.Now.AddMinutes(30);
            var credenciais = new SigningCredentials(nossaChave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                //issuer: emissorDoToken,
                //audience: destinatarioQueVaiUsar,
                claims: atributos,
                expires: tempoDeExpiracaoToken,
                signingCredentials: credenciais

                );

            var tokencompleto = new JwtSecurityTokenHandler().WriteToken(token);

            return tokencompleto;
        }

    }
}
