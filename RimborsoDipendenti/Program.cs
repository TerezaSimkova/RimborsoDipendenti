using RimborsoDipendenti.AdoRepository;
using RimborsoDipendenti.AdoRepository.AdoRepository;
using RimborsoDipendenti.Core;
using System;

namespace RimborsoDipendenti
{
    class Program
    {
        private static readonly IBusinessLayer bl = new BusinessLayer(new RepositoryAdoSpesa(), new RepositoryAdoDipendente());
        static void Main(string[] args)
        {
            try
            {
                bl.RimborsiApp();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, ex.InnerException.Source);
            }
                
            
         
        }
        //Rosposte parte 1:

        //1.
        // reference type - contiene solo puntatore(reference) nello stack al Heap dove si trova valore
        // value type invece contiene diretamente valore nello stack

        //2.
        // string,enum,object,tupla,funzioni,int,DateTime,struct,interface,delegate ecc..

        //3. 
        //.NET core è runtime, viene usato per creare delle app su mobile o web app oppure store su windows
        //.NET framework si puo usare per creare sia applicazioni per cellulari che per le app su desktop

    }
}
