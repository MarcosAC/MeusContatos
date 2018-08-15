using MeusContatos.Models;
using System.Collections.Generic;
using System.Linq;

namespace MeusContatos.BD
{
    public class DataBaseService
    {
        public void AdicionarContato(Contato contato)
        {
            DataBase.Conexao().Insert(contato);
        }

        public Contato ObterContato(int id)
        {
            return DataBase.Conexao().Table<Contato>().FirstOrDefault(c => c.IdContato == id);
        }

        public List<Contato> ObterTodosContatos()
        {
            return (from dadosContato in DataBase.Conexao().Table<Contato>() select dadosContato).ToList();
        }

        public void EditarContato(Contato contato)
        {
            DataBase.Conexao().Update(contato);
        }

        public void DeletarContato(int id)
        {
            DataBase.Conexao().Delete<Contato>(id);
        }

        public void DeletarTodosContatos()
        {
            DataBase.Conexao().DeleteAll<Contato>();
        }
    }
}
