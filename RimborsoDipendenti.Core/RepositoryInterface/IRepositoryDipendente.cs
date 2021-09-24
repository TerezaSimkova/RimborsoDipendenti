using RimborsoDipendenti.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RimborsoDipendenti.Core.RepositoryInterface
{
     public interface IRepositoryDipendente : IRepository<Dipendente>
    {
        public List<Dipendente> FetchAll();
    }
}
