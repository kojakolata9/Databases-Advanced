using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetVillainsNames
{
    class GetVillainsNames
    {
        static void Main(string[] args)
        {
            SqlConnection dbCon = new SqlConnection(
                   @"Server=(localdb)\MSSQLLocalDB; " +
                   "Database=MinionsDB; " +
                   "Integrated Security=true");
            dbCon.Open();
            string query = File.ReadAllText("../../VillainsNames.sql");
            using (dbCon)
            {
                SqlCommand com = new SqlCommand(query, dbCon);
                SqlDataReader reader = com.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string name = (string)reader[0];
                        int count = (int)reader[1];
                        Console.WriteLine("{0}  {1}", name, count);
                    }
                }
            }
        }
    }
}
