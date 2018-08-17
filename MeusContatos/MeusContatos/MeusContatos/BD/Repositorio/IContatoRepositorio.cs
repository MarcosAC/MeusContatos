using MeusContatos.Models;
using System.Collections.Generic;

namespace MeusContatos.BD.Repositorio
{
    public interface IContatoRepositorio
    {
        List<Contato> ObterTodosContatos();

        Contato ObterContato(int contatoId);

        void AdicionarContato(Contato contato);

        void EditarContato(Contato contato);

        void DeletarContato(int contatoId);

        void DeletarTodosContatos();
    }
}
