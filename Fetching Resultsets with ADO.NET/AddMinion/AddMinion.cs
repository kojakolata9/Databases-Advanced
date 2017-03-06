using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddMinion
{
    class AddMinion
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(
                 @"Server=(localdb)\MSSQLLocalDB; " +
                 "Database=MinionsDB; " +
                 "Integrated Security=true");

            Console.Write("Minion: ");
            string input = Console.ReadLine();
            var inputMinion = input.Split(' ');
            Console.Write("Vallain: ");
            string inputVallain = Console.ReadLine();

            connection.Open();

            using (connection)
            {
                insertTown(connection, inputMinion);
                int townID = townCheck(connection, inputMinion);
                inserMinion(connection, inputMinion, townID);
                int minionId = minionCheck(connection, inputMinion);
                insertVillain(connection, inputVallain);
                int villainId = villainCheck(connection, inputVallain);
                SetMinionToServe(connection, minionId, villainId, inputMinion[0], inputVallain);
            }

        }

        private static void SetMinionToServe(SqlConnection connection, int minionId, int villainId, string minion, string villain)
        {
            string query = "insert into MinionsVillains values(@minion, @vallain)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@minion", minionId);
            command.Parameters.AddWithValue("@vallain", villainId);
            int result = command.ExecuteNonQuery();

            if (result > 0)
            {
                Console.WriteLine($"Successfully added {minion} to be minion of {villain}");
            }
        }

        private static void insertVillain(SqlConnection connection, string villain)
        {
            string villainName = villain;
            SqlCommand com = new SqlCommand("SELECT COUNT(Id) FROM Villains", connection);
            int id = (int)com.ExecuteScalar();
            string query = "INSERT INTO Villains (Id,Name, EvilnessFactor) ";
            query += "VALUES (@id,@villainName, 'evil')";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@villainName", villainName);
            command.Parameters.AddWithValue("@id", id+1);
            var result = command.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine($"Villain {villainName} was added to the database.");
            }
            else
            {
                Console.WriteLine("Villain already exist!");
            }
        }

        private static void insertTown(SqlConnection connection, string[] inputMinion)
        {
            string Town = inputMinion[2];
            SqlCommand com = new SqlCommand("SELECT COUNT(Id) FROM Towns", connection);
            int id = (int)com.ExecuteScalar();
            string query = "INSERT INTO Towns (Id,TownName)";
            query += "VALUES (@id,@Town)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Town", Town);
            command.Parameters.AddWithValue("@id", id+1);
            var result = command.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine($"Town {Town} was added to the database.");
            }
            else
            {
                Console.WriteLine("Alredy exist!");
            }
        }
        private static int townCheck(SqlConnection connection, string[] inputMinion)
        {
            string town = inputMinion[2];
            string query = "select Id from Towns WHERE TownName=@Town";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Town", town);
            int results = (int)command.ExecuteScalar();
            return results;
        }

        private static int villainCheck(SqlConnection connection, string vallain)
        {
            string vallainId = vallain;
            string query = "select Id from Villains";
            query += " WHERE Name=@vallain";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@vallain", vallainId);
            int results = (int)command.ExecuteScalar();
            return results;
        }

        private static int minionCheck(SqlConnection connection, string[] inputMinion)
        {
            string minionId = inputMinion[0];
            string query = "select Id from Minions";
            query += " WHERE Name=@minion";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@minion", minionId);
            int results = (int)command.ExecuteScalar();
            return results;
        }

        private static void inserMinion(SqlConnection connection, string[] inputMinion, int town)
        {
            string name = inputMinion[0];
            int age = int.Parse(inputMinion[1]);
            int townId = town;
            SqlCommand com = new SqlCommand("SELECT COUNT(Id) FROM Minions", connection);
            int id = (int)com.ExecuteScalar();
            string minionQuery = "INSERT INTO Minions (Id,Name, Age, TownId)";
            minionQuery += " values (@id,@Name, @Age, @TownId)";
            SqlCommand command = new SqlCommand(minionQuery, connection);
            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@Age", age);
            command.Parameters.AddWithValue("@TownId", townId);
            command.Parameters.AddWithValue("@id", id+1);
            var result = command.ExecuteNonQuery();

            if (result > 0)
            {
                Console.WriteLine($"Successfully added minion with {name}.");
            }
            else
            {
                Console.WriteLine("Error when trying to insert minion!");
            }
        }
    }
}
