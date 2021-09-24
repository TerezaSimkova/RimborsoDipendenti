using RimborsoDipendenti.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RimborsoDipendenti.Core.RepositoryInterface
{
    public interface IRepositorySpesa : IRepository<Spese>
    {
        List<Spese> GetSpeseValoriMancanti();
        public void UpdateRimborso(Spese rimborso);
        void UpdateRimborso1(Spese spesa);

    }
}
