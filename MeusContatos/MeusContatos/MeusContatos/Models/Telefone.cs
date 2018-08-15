using SQLite;

namespace MeusContatos.Models
{
    [Table("Telefone")]
    public class Telefone
    {
        [PrimaryKey, AutoIncrement]
        public int IdTelefone { get; set; }
        public string Celular { get; set; }
        public string TefoneFixo { get; set; }
    }
}
