using System;
using TesteDapper.App.Entidades;
using TesteDapper.App.Repositorios;

namespace TesteDapper.App
{
    class Program
    {
        static void Main(string[] args)
        {
            //MainMontadora();

            MainCarro();

            Console.Read();
        }

        private static void MainCarro()
        {
            var carroRepositorio = new CarroRepositorio();

            var carros = carroRepositorio.GetAll();

            foreach (var carro in carros)
            {
                Console.WriteLine($"Id: {carro.Id} - Nome: {carro.Nome} - Modelo: {carro.Modelo} - AnoFabricacao: {carro.AnoFabricacao} - Montadora: {carro.Montadora.Nome} - PaisOrigem: {carro.Montadora.PaisOrigem}");
            }
        }


        private static void MainMontadora()
        {
            var montadoraRepositorio = new MontadoraContribRepositorio();
            //var montadoraRepositorio = new MontadoraRepositorio();

            Console.WriteLine("> Listando todas as montadoras");
            var montadoras = montadoraRepositorio.GetAll();
            foreach (var montadora in montadoras)
            {
                Console.WriteLine($"Id: {montadora.Id} - Nome: {montadora.Nome} - País de Origem: {montadora.PaisOrigem}");
            }

            Console.WriteLine("> Incluindo nova montadora");
            var result = montadoraRepositorio.Insert(new Montadora()
            {
                Id = 5,
                Nome = "HoMda",
                PaisOrigem = "China"
            });
            Console.WriteLine($"Montadora foi incluída? {result}");

            Console.WriteLine("> Listando a nova montadora");
            var novaMontadora = montadoraRepositorio.Get(5);
            Console.WriteLine($"Id: {novaMontadora.Id} - Nome: {novaMontadora.Nome} - País de Origem: {novaMontadora.PaisOrigem}");

            Console.WriteLine("> Atualizando a nova montadora");
            result = montadoraRepositorio.Update(new Montadora()
            {
                Id = 5,
                Nome = "Honda",
                PaisOrigem = "Japão"
            });
            Console.WriteLine($"Montadora foi atualizada? {result}");

            Console.WriteLine("> Listando a montadora atualizada");
            var montadoraAtualizada = montadoraRepositorio.Get(5);
            Console.WriteLine($"Id: {montadoraAtualizada.Id} - Nome: {montadoraAtualizada.Nome} - País de Origem: {montadoraAtualizada.PaisOrigem}");

            Console.WriteLine("> Excluindo uma montadora");
            var montadoraApagada = montadoraRepositorio.Delete(5);
            Console.WriteLine($"Montadora foi apagada? {montadoraApagada}");
        }

    }
}
