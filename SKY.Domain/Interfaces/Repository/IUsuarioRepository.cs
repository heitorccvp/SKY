using SKY.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SKY.Domain.Interfaces.Repository
{
	public interface IUsuarioRepository
	{
		IEnumerable<Usuario> BuscarTodos();

		Usuario BuscarUsuario(string email);

		Usuario Inserir(Usuario inserirUsuarioModel);

		Usuario Alterar(Usuario alterarUsuarioModel);

		int Excluir(Guid id);

	}
}
