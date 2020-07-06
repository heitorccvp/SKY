using SKY.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SKY.Domain.Interfaces.Repository
{
	public interface ITelefoneRepository
	{
		IEnumerable<Telefone> BuscarTodos();

		Telefone BuscarTelefone(int id);

		Telefone Inserir(Telefone inserirTelefone);

		Telefone Alterar(Telefone alterarTelefone);

		int Excluir(int id);
	}
}
