using RimborsoDipendenti.Core.Entities;
using RimborsoDipendenti.Core.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RimborsoDipendenti.Core.Entities.Spese;

namespace RimborsoDipendenti.AdoRepository
{
    public class RepositoryAdoSpesa : IRepositorySpesa
    {
        const string connectionString = @"Data Source = (localdb)\mssqllocaldb; Initial Catalog=AcademyI.EsercitazioneFinale; Integrated Security=true;";


        public List<Spese> GetSpeseValoriMancanti()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Spese where Approvata is null and Rimborso is null and Approvatore is null";

                SqlDataReader reader = command.ExecuteReader();
                List<Spese> speseAll = new List<Spese>();

                while (reader.Read())
                {
                    Spese spesa= new Spese();

                    spesa.Id = (int)reader["Id"];
                    spesa.Data = (DateTime)reader["Data"];
                    spesa.Spesa = Convert.ToSingle(reader["Spesa"]);
                    spesa.Categoria = (CategoriaE)reader["Categoria"];

                    speseAll.Add(spesa);
                }
                return speseAll;
            }
        }

        public void UpdateRimborso(Spese rimborso)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "update dbo.Spese set Approvata = @approvata, Rimborso = @rimborso, Approvatore = @approva where Id = @id";
             
                command.Parameters.AddWithValue("@approvata", rimborso.Approvato);
                command.Parameters.AddWithValue("@id", rimborso.Id);
                command.Parameters.AddWithValue("@rimborso", rimborso.Rimborso);
                command.Parameters.AddWithValue("@approva", rimborso.Approvatore);

               

                command.ExecuteNonQuery();
            }
        }

        public void UpdateRimborso1(Spese spesa)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "update dbo.Spese set Approvata = @approvata, Rimborso = @rimborso, Approvatore = @approva where Id = @id";
                command.Parameters.AddWithValue("@approvata", DBNull.Value); //TODO questa parte e da eggiustare non funziona
                command.Parameters.AddWithValue("@id", DBNull.Value);
                command.Parameters.AddWithValue("@approva", DBNull.Value);
                command.Parameters.AddWithValue("@rimborso", DBNull.Value);
                command.Parameters.AddWithValue("@approva", DBNull.Value); 

                command.ExecuteNonQuery();
            }
        }
    }
}
