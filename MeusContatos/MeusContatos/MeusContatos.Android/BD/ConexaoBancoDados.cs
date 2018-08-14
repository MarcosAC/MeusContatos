using MeusContatos.BD;
using System.IO;

namespace MeusContatos.Droid.BD
{
    public class ConexaoBancoDados : IConexaoBancoDados
    {
        public string Conexao(string NomeArquivoBD)
        {
            string stringConexao = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string bancoDados = Path.Combine(stringConexao, NomeArquivoBD);
            return bancoDados;
        }
    }
}