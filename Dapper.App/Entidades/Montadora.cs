using Dapper.Contrib.Extensions;

namespace TesteDapper.App.Entidades
{
    [Table("Montadora")]
    public class Montadora
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string PaisOrigem { get; set; }
    }
}