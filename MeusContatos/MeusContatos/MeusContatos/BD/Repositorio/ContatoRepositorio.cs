using MeusContatos.Models;
using System.Collections.Generic;

namespace MeusContatos.BD.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        DataBase _dataBase;

        public ContatoRepositorio()
        {
            _dataBase = new DataBase();
        }

        public void AdicionarContato(Contato contato)
        {
            _dataBase.AdicionarContato(contato);
        }

        public void DeletarContato(int contatoId)
        {
            _dataBase.DeletarContato(contatoId);
        }

        public void DeletarTodosContatos()
        {
            _dataBase.DeletarTodosContatos();
        }

        public void EditarContato(Contato contato)
        {
            _dataBase.EditarContato(contato);
        }

        public Contato ObterContato(int contatoId)
        {
            return _dataBase.ObterContato(contatoId);
        }

        public List<Contato> ObterTodosContatos()
        {
            return _dataBase.ObterTodosContatos();
        }
    }
}
