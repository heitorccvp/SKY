using ServiceStack.Host;
using SKY.Domain.Interfaces;
using SKY.Domain.Interfaces.Repository;
using SKY.Domain.Models;
using SKY.Infra.Shared.Mapper;
using SKY.Infra.Shared.Util;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web;

namespace SKY.Service.Services
{
	public class UsuarioService : IUsuarioService
	{

		private readonly IUsuarioRepository _usuarioRepository;

		public UsuarioService(IUsuarioRepository usuarioRepository)
		{
			_usuarioRepository = usuarioRepository;
		}

		public IEnumerable<UsuarioModel> BuscarTodos()
		{
			var usuarios = _usuarioRepository.BuscarTodos();
			return usuarios.ConverterModelUsuarios();
		}

		public UsuarioModel BuscarUsuario(string email)
		{
			var usuario = _usuarioRepository.BuscarUsuario(email);

			return usuario.ConverterModelUsuario();
		}

		public UsuarioModel Inserir(InserirUsuarioModel inserirUsuarioModel)
		{
			var usuario = inserirUsuarioModel.ConverterEntidadeUsuario();

			return _usuarioRepository.Inserir(usuario).ConverterModelUsuario();
		}

		public UsuarioModel Alterar(AlterarUsuarioModel alterarUsuarioModel)
		{
			var usuario = alterarUsuarioModel.ConverterEntidadeUsuario();

			return _usuarioRepository.Alterar(usuario).ConverterModelUsuario();
		}

		public int Excluir(Guid id)
		{
			return _usuarioRepository.Excluir(id);
		}

		public UsuarioModel Logar(UsuarioSingInModel usuarioSingInModel)
		{
			var usuario = _usuarioRepository.BuscarUsuario(usuarioSingInModel.email);

			if (usuarioSingInModel.email == usuario.email
					&& usuarioSingInModel.senha.RetornarHash() == usuario.senha)
			{
				if (usuario.ultimo_login == null)
				{
					usuario.token = GerarToken.GerarJwt(usuario);
					usuario.ultimo_login = DateTime.Now;
					//Todo atualizar login
					_usuarioRepository.Alterar(usuario);
				}
				else if (usuario.ultimo_login != null && TratamentoData.intervaloDeMinutos(Convert.ToDateTime(usuario.ultimo_login), DateTime.Now) >= 30)
				{
					usuario.token = GerarToken.GerarJwt(usuario);
					usuario.ultimo_login = DateTime.Now;
					_usuarioRepository.Alterar(usuario);
				}

				return usuario.ConverterModelUsuario();
			}
			else if (usuarioSingInModel.email == usuario.email && usuarioSingInModel.senha.RetornarHash() != usuario.senha)
			{
				throw new HttpException(401, "Usuário e/ou senha inválidos");
			}
			else if (usuarioSingInModel.email != usuario.email && usuarioSingInModel.senha.RetornarHash() != usuario.senha)
			{
				throw new HttpException(400, "Usuário e/ou senha inválidos");
			}
			else
				throw new Exception("Usuário e/ou senha inválidos");
		}


	}
}
