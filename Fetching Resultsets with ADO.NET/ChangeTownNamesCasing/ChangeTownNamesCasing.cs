using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetMinionNames
{
    class GetMinionNames
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            SqlConnection dbCon = new SqlConnection(
                  @"Server=(localdb)\MSSQLLocalDB; " +
                  "Database=MinionsDB; " +
                  "Integrated Security=true");
            dbCon.Open();
            List<string> list = new List<string>();
            using (dbCon)
            {
                SqlCommand com = new SqlCommand("SELECT TOP(1) Id FROM Countries WHERE CountryName='" + name+"'", dbCon);
                int id =(int) com.ExecuteScalar();
                
                SqlCommand command = new SqlCommand(@"SELECT TownName FROM Towns 
                    WHERE CountryId = " + id, dbCon);
                SqlDataReader readTowns = command.ExecuteReader();
                using (readTowns)
                {
                    while (readTowns.Read())
                    {
                        list.Add(((string)readTowns[0]).ToUpper());
                    }
                }
                if (list.Count == 0)
                {
                    Console.WriteLine("No town names were affected");
                }
                else
                {
                    SqlCommand command1 = new SqlCommand(@"UPDATE Towns
                    SET TownName = UPPER(TownName)
                    WHERE CountryId =" + id, dbCon);
                    command1.ExecuteNonQuery();
                    Console.WriteLine(list.Count+ " town names were affected.");
                    Console.WriteLine("["+String.Join(", ",list.ToArray())+"]");
                }
            }
        }
    }
}
