using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ADONetUpg
{
    public class DbLogic
    {
        public void ActorNameStart(string firstName,string lastName)
        {
            var connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Sakila;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

            connection.Open();

            var command = new SqlCommand($"SELECT * FROM actor WHERE first_name ='{firstName}' AND last_name='{lastName}'", connection);

            var result = command.ExecuteReader();
            if (result.HasRows)
            {
                Console.WriteLine("\nActor Name");
                while (result.Read())
                {
                    var actorId = result[0];
                    Console.Write(result[1] + "\t");
                    Console.WriteLine(result[2]+"\n");
                    FilmByActor(actorId);

                }
            }
            connection.Close();
        }

        public void FilmByActor(object actorId)
        {
            var connection1 = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Sakila;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

            connection1.Open();

            var filmCommand = new SqlCommand($"SELECT f.film_id, f.title FROM film_actor fa JOIN film f ON fa.film_id = f.film_id WHERE fa.actor_id = {actorId}", connection1);


            var filmResult = filmCommand.ExecuteReader();
            if (filmResult.HasRows)
            {
                Console.WriteLine("Films:");
                Console.WriteLine("Title");
                while (filmResult.Read())
                {
                    Console.WriteLine(filmResult[1]);
                }
            }

            connection1.Close();
        }


    }
}
