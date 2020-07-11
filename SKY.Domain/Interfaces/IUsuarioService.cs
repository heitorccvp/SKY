using SKY.Domain.Models;
using System;
using System.Collections.Generic;

namespace SKY.Domain.Interfaces
{
	public interface IUsuarioService
	{
		IEnumerable<UsuarioModel> BuscarTodos();

		UsuarioModel BuscarUsuario(string email);

		UsuarioModel Inserir(InserirUsuarioModel inserirUsuarioModel);

		UsuarioModel Alterar(AlterarUsuarioModel alterarUsuarioModel);

		int Excluir(Guid id);

		UsuarioModel Logar(UsuarioSingInModel usuarioSingInModel);

		UsuarioModel BuscarUsuarioPorId(Guid id);
	}
}
