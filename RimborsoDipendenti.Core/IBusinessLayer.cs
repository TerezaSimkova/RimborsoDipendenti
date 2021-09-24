using RimborsoDipendenti.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RimborsoDipendenti.Core
{
    public interface IBusinessLayer
    {
        void RimborsiApp();
        public List<Dipendente> ExistNameInDb(string nome);
    }
}
