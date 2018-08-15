using MeusContatos.Models;
using SQLite;
using Xamarin.Forms;

namespace MeusContatos.BD
{
    public class DataBase
    {
        private static SQLiteConnection _conexao;

        public DataBase()
        {
            // Injeção de dependencia da Interface onde irei setar a conexao do banco de dados.
            var dependencyService = DependencyService.Get<IConexaoBancoDados>();

            // Variavel que recebe a injeção de dependencia com o banco de dados.
            string stringConexao = dependencyService.Conexao("contatos.sqlite");

            // Conexão com o banco de dados.
            _conexao = new SQLiteConnection(stringConexao);

            _conexao.CreateTable<Contato>();
            _conexao.CreateTable<Telefone>();
        }

        public static SQLiteConnection Conexao()
        {
            return _conexao;
        }
    }
}
