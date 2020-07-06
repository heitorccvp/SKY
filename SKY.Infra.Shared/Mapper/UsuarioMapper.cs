using SKY.Domain.Entities;
using SKY.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SKY.Infra.Shared.Mapper
{
	public static class UsuarioMapper
	{
		public static IEnumerable<UsuarioModel> ConverterModelUsuarios(this IEnumerable<Usuario> usuarios)
		{
			return usuarios.Select(usuario => new UsuarioModel(
					usuario.id,
					usuario.nome,
					usuario.email,
					usuario.telefones.Select(telefone => new TelefoneModel(telefone.id, telefone.ddd, telefone.numero)).ToList(),
					usuario.token
				));
		}

		public static UsuarioModel ConverterModelUsuario(this Usuario usuario)
		{
			return new UsuarioModel(usuario.id, usuario.nome, usuario.email,
				usuario.telefones.Select(telefone => new TelefoneModel(telefone.id, telefone.ddd, telefone.numero)).ToList(),
				usuario.token
				);
		}

		public static Usuario ConverterEntidadeUsuario(this InserirUsuarioModel usuarioModel)
		{
			return new Usuario(Guid.NewGuid(), usuarioModel.nome, usuarioModel.email, usuarioModel.senha,
				usuarioModel.telefones.Select(telefone => new Telefone(Guid.NewGuid(), telefone.ddd, telefone.numero)).ToList()
				);

		}

		public static Usuario ConverterEntidadeUsuario(this AlterarUsuarioModel usuarioModel)
		{
			return new Usuario(usuarioModel.id, usuarioModel.nome, usuarioModel.email, usuarioModel.senha,
				usuarioModel.telefones.Select(telefone => new Telefone(telefone.id, telefone.ddd, telefone.numero)).ToList()
				);
		}


	}
}
