using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RimborsoDipendenti.Core.Entities
{
    public class Spese
    {
        public int Id { get; set; }
        public DateTime Data { get; set; } 
        public float Spesa { get; set; }
        public CategoriaE Categoria { get; set; }
        public bool? Approvato { get; set; }
        public float? Rimborso { get; set; }
        public ApprovatoreE? Approvatore { get; set; }


        public Spese() { }
        
        public Spese(int id, DateTime data, float spesa, CategoriaE categoria, bool approvato, float rimborso, ApprovatoreE approvatore)
        {
            Id = id;
            Data = data;
            Spesa = spesa;
            Categoria = categoria;
            Approvato = approvato;
            Rimborso = rimborso;
            Approvatore = approvatore;

        }

        public enum CategoriaE
        {
            Vitto = 1,
            Alloggio =2,
            Trasferta =3,
            Altro=4
        }

        public enum ApprovatoreE
        {
            Manager = 1,
            Operation_Manager = 2,
            CEO = 3
        }
    }
}
