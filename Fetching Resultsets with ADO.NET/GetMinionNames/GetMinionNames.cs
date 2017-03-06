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
            int id = int.Parse(Console.ReadLine());
            SqlConnection dbCon = new SqlConnection(
                  @"Server=(localdb)\MSSQLLocalDB; " +
                  "Database=MinionsDB; " +
                  "Integrated Security=true");
            dbCon.Open();
            using (dbCon)
            {
                SqlCommand com = new SqlCommand("SELECT Name FROM Villains WHERE Id="+id, dbCon);
                SqlDataReader readVillainNames = com.ExecuteReader();
                using (readVillainNames)
                {
                    if(readVillainNames.Read())
                    {
                        Console.WriteLine("Villain: {0}", readVillainNames[0]);
                    }
                }
                SqlCommand command = new SqlCommand(@"SELECT m.Id,m.Name,m.Age FROM Minions AS m
                    JOIN MinionsVillains AS mv
                    ON mv.MinionId = m.Id
                    WHERE mv.VillainId = " + id, dbCon);
                SqlDataReader readMinions = command.ExecuteReader();
                using (readMinions)
                {
                    while(readMinions.Read())
                    {
                        Console.WriteLine("{0}.  {1}  {2}", readMinions[0], readMinions[1], readMinions[2]);
                    }
                }
            }
        }
    }
}
