using System.Collections.Generic;
using System.Configuration;
using Dapper.Contrib.Extensions;
using TesteDapper.App.Entidades;

namespace TesteDapper.App.Repositorios
{
    public class MontadoraContribRepositorio : IMontadoraRepositorio
    {
        public string ConnectionString = ConfigurationManager.ConnectionStrings["DbSample"].ConnectionString;

        public IEnumerable<Montadora> GetAll()
        {
            using (var db = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                return db.GetAll<Montadora>();
            }
        }

        public bool Insert(Montadora montadora)
        {
            using (var db = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                var data = db.Insert(montadora);

                return data > 0;
            }
        }

        public bool Update(Montadora montadora)
        {
            using (var db = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                return db.Update(montadora);
            }
        }

        public bool Delete(int id)
        {
            using (var db = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                return db.Delete(new Montadora() {Id = id});
            }
        }

        public Montadora Get(int id)
        {
            using (var db = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                return db.Get<Montadora>(id);
            }
        }
    }
}