using RimborsoDipendenti.AdoRepository;
using RimborsoDipendenti.AdoRepository.AdoRepository;
using RimborsoDipendenti.Core;
using System;
using System.IO;

namespace RimborsoDipendenti.Login
{
    class Program
    {
        private static readonly IBusinessLayer bl = new BusinessLayer(new RepositoryAdoSpesa(), new RepositoryAdoDipendente());
        static void Main(string[] args)
        {
            Login();
        }

        private static void Login()
        {
            Console.WriteLine("Ciao come ti chiami?");
            string nome = Console.ReadLine();

            var nomeList = bl.ExistNameInDb(nome);

            //aggiungere delegate + una join di dipendente e spese per poter fare la stampa

            foreach (var item in nomeList)
            {
                if (item.Nome == nome)
                {
                    string path = @"C:\Users\tereza.simkova\source\repos\RimborsoDipendenti\RimborsoDipendenti\Riepiologo.txt";

                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        sw.WriteLine();
                    }
                }
               
            }
           

        }
    }
}
