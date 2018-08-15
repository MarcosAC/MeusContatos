using MeusContatos.Models;
using System.Collections.Generic;

namespace MeusContatos.BD.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        DataBaseService _dataBaseService;

        public ContatoRepositorio()
        {
            _dataBaseService = new DataBaseService();
        }

        public void AdicionarContato(Contato contato)
        {
            _dataBaseService.AdicionarContato(contato);
        }

        public void DeletarContato(int contatoId)
        {
            _dataBaseService.DeletarContato(contatoId);
        }

        public void DeletarTodosContatos()
        {
            _dataBaseService.DeletarTodosContatos();
        }

        public void EditarContato(Contato contato)
        {
            _dataBaseService.EditarContato(contato);
        }

        public Contato ObterContato(int contatoId)
        {
            return _dataBaseService.ObterContato(contatoId);
        }

        public List<Contato> ObterTodosContat()
        {
            return _dataBaseService.ObterTodosContatos();
        }
    }
}
