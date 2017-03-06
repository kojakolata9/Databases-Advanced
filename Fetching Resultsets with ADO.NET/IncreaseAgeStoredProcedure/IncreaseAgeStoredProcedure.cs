using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncreaseAgeStoredProcedure
{
    class IncreaseAgeStoredProcedure
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

                SqlCommand com1 = new SqlCommand("EXEC usp_GetOlder @id", dbCon);
                SqlParameter param = new SqlParameter("@id",id);
                com1.Parameters.Add(param);
                com1.ExecuteNonQuery();
                SqlCommand com2 = new SqlCommand("SELECT Name,Age FROM Minions WHERE Id="+id, dbCon);
                
                SqlDataReader readMinions = com2.ExecuteReader();
                using (readMinions)
                {
                    while (readMinions.Read())
                    {
                        
                        Console.WriteLine("{0}  {1}", readMinions[0], readMinions[1]);
                    }
                }
            }
        }
    }
}
