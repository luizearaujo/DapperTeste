using Dapper.Contrib.Extensions;

namespace TesteDapper.App.Entidades
{
    public class Carro
    {
        [Key]
        public int Id { get; set; }

        public Montadora Montadora { get; set; }
        

        public string Nome { get; set; }

        public string Modelo { get; set; }

        public int AnoFabricacao { get; set; }
    }
}