using System.Collections.Generic;
using TesteDapper.App.Entidades;

namespace TesteDapper.App.Repositorios
{
    public interface IMontadoraRepositorio
    {
        IEnumerable<Montadora> GetAll();

        bool Insert(Montadora montadora);

        bool Update(Montadora montadora);

        bool Delete(int id);

        Montadora Get(int id);

    }
}