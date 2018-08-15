using SQLite;

namespace MeusContatos.Models
{
    [Table("Contato")]
    public class Contato
    {
        [PrimaryKey, AutoIncrement]
        public int IdContato { get; set; }
        public string NomeContato { get; set; }
        public Telefone Telefone { get; set; }
    }
}
