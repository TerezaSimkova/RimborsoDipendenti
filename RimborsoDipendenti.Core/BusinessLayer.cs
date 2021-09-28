using RimborsoDipendenti.Core.Entities;
using RimborsoDipendenti.Core.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RimborsoDipendenti.Core
{
    public class BusinessLayer : IBusinessLayer
    {

        private readonly IRepositorySpesa spesaRepo;
        private readonly IRepositoryDipendente dipRepo;

        public BusinessLayer(IRepositorySpesa repositorySpesa, IRepositoryDipendente dipendente)
        {
            spesaRepo = repositorySpesa;
            dipRepo = dipendente;
        }

        public void RimborsiApp()
        {
            List<Spese> speseConIValoriMancanti = new List<Spese>();
            speseConIValoriMancanti = spesaRepo.GetSpeseValoriMancanti();

            if (speseConIValoriMancanti.Count() > 0)
            {
                foreach (var spesa in speseConIValoriMancanti)
                {
                    if (spesa.Spesa > 0 && spesa.Spesa < 2500)
                    {
                        spesa.Approvato = true;
                    }


                    if (spesa.Spesa <= 400) spesa.Approvatore = Spese.ApprovatoreE.Manager;

                    else if (spesa.Spesa > 401 && spesa.Spesa < 1000) spesa.Approvatore = Spese.ApprovatoreE.Operation_Manager;

                    else if (spesa.Spesa >= 1000 && spesa.Spesa < 2500) spesa.Approvatore = Spese.ApprovatoreE.CEO;

                    else if (spesa.Spesa > 2500)
                    {
                        spesaRepo.UpdateRimborso(spesa);
                        continue;
                    }

                    float rimborso = 0;
                    if (spesa.Categoria == Spese.CategoriaE.Vitto)
                    {
                        rimborso = spesa.Spesa * 70 / 100;
                    }
                    else if (spesa.Categoria == Spese.CategoriaE.Alloggio)
                    {
                        rimborso = spesa.Spesa * 100 / 100;
                    }
                    else if (spesa.Categoria == Spese.CategoriaE.Trasferta)
                    {
                        rimborso = spesa.Spesa * 50 / 100 + 50;
                    }
                    else if (spesa.Categoria == Spese.CategoriaE.Altro)
                    {
                        rimborso = spesa.Spesa * 10 / 100;
                    }

                    spesa.Rimborso = rimborso;
                    spesaRepo.UpdateRimborso(spesa);
                }
            }
        }

        List<Dipendente> IBusinessLayer.ExistNameInDb(string nome)
        {
            var dipendeni = dipRepo.FetchAll();
            return dipendeni;

            //TODO torno lista dei dipendenti e faccio la stampa sull file
        }
    }
}
