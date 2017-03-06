using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Initial_Setup
{
    class InitialSetup
    {
        static void Main(string[] args)
        {
            string query=File.ReadAllText("../../Initial Setup.sql");
            SqlConnection dbCon = new SqlConnection(
                @"Server=(localdb)\MSSQLLocalDB; " +
                "Integrated Security=true");
            dbCon.Open();
            using (dbCon)


            {
                SqlCommand command = new SqlCommand("CREATE DATABASE MinionsDB", dbCon);
                command.ExecuteNonQuery();
                SqlCommand com = new SqlCommand(query, dbCon);
                com.ExecuteNonQuery();
            }
        }
    }
}
