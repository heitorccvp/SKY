using SKY.Domain.Models;
using System;
using System.Collections.Generic;

namespace SKY.Domain.Interfaces
{
	public interface ITelefoneService
	{
		IEnumerable<TelefoneModel> BuscarTodos();

		TelefoneModel BuscarTelefone(int id);

		TelefoneModel Inserir(InserirTelefoneModel inserirTelefoneModel);

		TelefoneModel Alterar(AlterarTelefoneModel alterarTelefoneModel);

		int Excluir(int id);
	}
}
