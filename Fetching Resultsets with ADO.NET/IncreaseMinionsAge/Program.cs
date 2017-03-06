using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncreaseMinionsAge
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                SqlConnection dbCon = new SqlConnection(
                 @"Server=(localdb)\MSSQLLocalDB; " +
                 "Database=MinionsDB; " +
                 "Integrated Security=true");
            dbCon.Open();
            using (dbCon)
            {

                SqlCommand com2 = new SqlCommand("UPDATE Minions SET Age=Age+1 WHERE Id IN(" + String.Join(",", arr)+")", dbCon);
                com2.ExecuteNonQuery();
                SqlCommand com3 = new SqlCommand("SELECT Id,Name,Age FROM Minions", dbCon);
                SqlDataReader readMinions = com3.ExecuteReader();
                using (readMinions)
                {
                    while (readMinions.Read())
                    {
                        string item = (string)(readMinions[1]);
                        if (arr.Contains((int)(readMinions[0])))
                        {
                            item = char.ToUpper(item[0]) + item.Substring(1);
                            SqlCommand com4 = new SqlCommand("UPDATE Minions SET Name=" + item + " WHERE Id IN(" + String.Join(",", arr) + ")", dbCon);
                            com4.ExecuteNonQuery();
                        }
                        Console.WriteLine("{0}  {1}", item, readMinions[2]);
                    }
                }
            }
        }
    }
}
