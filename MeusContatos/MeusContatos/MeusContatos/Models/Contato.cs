using SQLite;

namespace MeusContatos.Models
{
    [Table("Contato")]
    public class Contato
    {
        [PrimaryKey, AutoIncrement]
        public int IdContato { get; set; }
        public string NomeContato { get; set; }
        public string Celular { get; set; }
        public string TelefoneFixo { get; set; }
    }
}
