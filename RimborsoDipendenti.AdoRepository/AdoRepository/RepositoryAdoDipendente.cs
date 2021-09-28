using RimborsoDipendenti.Core.Entities;
using RimborsoDipendenti.Core.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RimborsoDipendenti.AdoRepository.AdoRepository
{
    public class RepositoryAdoDipendente : IRepositoryDipendente
    {
        const string connectionString = @"Data Source = (localdb)\mssqllocaldb; Initial Catalog=AcademyI.EsercitazioneFinale; Integrated Security=true;";

        public List<Dipendente> FetchAll()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from dbo.Dipendenti";

                SqlDataReader reader = command.ExecuteReader();

                List<Dipendente> iDip = new List<Dipendente>();

                while (reader.Read())
                {
                    Dipendente dipendente = new Dipendente();
                    dipendente.Id = (int)reader["Id"];
                    dipendente.Nome = (string)reader["Nome"];

                    iDip.Add(dipendente);
                }
                return iDip;
            }
        }
    }
}
