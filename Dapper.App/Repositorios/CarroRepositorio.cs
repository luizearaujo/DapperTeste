using System.Collections.Generic;
using System.Configuration;
using Dapper;
using Dapper.Contrib.Extensions;
using TesteDapper.App.Entidades;

namespace TesteDapper.App.Repositorios
{
    public class CarroRepositorio
    {
        public string ConnectionString = ConfigurationManager.ConnectionStrings["DbSample"].ConnectionString;

        public IEnumerable<Carro> GetAll()
        {

            var query = @"select Carro.Id, Carro.Nome, Carro.Modelo, Carro.AnoFabricacao, Carro.MontadoraId, Montadora.Nome, Montadora.PaisOrigem 
                            from 	Carro,	Montadora where Carro.MontadoraId = Montadora.Id";

            using (var db = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                var data = db.Query<Carro, Montadora, Carro>(query,
                    (carro, montadora) =>
                    {
                        carro.Montadora = montadora;
                        return carro;
                    }, null, null, true, "MontadoraId");

                return data;
            }
    }


}
}