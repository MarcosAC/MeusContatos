using MeusContatos.Models;
using System.Collections.Generic;

namespace MeusContatos.BD.Repositorio
{
    public interface IContatoRepositorio
    {
        List<Contato> ObterTodosContatos();

        List<Contato> PesquisarContato(string filtro);

        Contato ObterContato(int contatoId);

        void AdicionarContato(Contato contato);

        void EditarContato(Contato contato);

        void DeletarContato(int contatoId);

        void DeletarTodosContatos();
    }
}
