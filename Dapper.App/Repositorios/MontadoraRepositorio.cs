using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Dapper;
using TesteDapper.App.Entidades;

namespace TesteDapper.App.Repositorios
{
    public class MontadoraRepositorio : IMontadoraRepositorio
    {

        public string ConnectionString = ConfigurationManager.ConnectionStrings["DbSample"].ConnectionString;

        public IEnumerable<Montadora> GetAll()
        {
            using (var db = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                var data = db.Query<Montadora>("SELECT Id ,Nome ,PaisOrigem FROM Montadora");

                return data;
            }
        }

        public bool Insert(Montadora montadora)
        {
            using (var db = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                var data = db.Execute("insert into Montadora (Id, Nome, PaisOrigem) values(@Id, @Nome, @PaisOrigem)",
                    new {Id = montadora.Id, Nome = montadora.Nome, PaisOrigem = montadora.PaisOrigem});

                return data > 0;
            }
        }

        public bool Update(Montadora montadora)
        {
            using (var db = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                var data = db.Execute("update Montadora set Nome = @Nome, PaisOrigem = @PaisOrigem where Id = @Id",
                    new {montadora.Nome, montadora.PaisOrigem, montadora.Id});

                return data > 0;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                var data = db.Execute("delete from Montadora where Id = @Id", new {Id = id});

                return data > 0;
            }
        }

        public Montadora Get(int id)
        {
            using (var db = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                var data = db.Query<Montadora>("SELECT Id ,Nome ,PaisOrigem FROM Montadora where Id = @Id", new {Id = id}).FirstOrDefault();

                return data;
            }
        }
    }
}