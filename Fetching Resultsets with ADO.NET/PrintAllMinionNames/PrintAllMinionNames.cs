using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintAllMinionNames
{
    class PrintAllMinionNames
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            List<string> listOrdered = new List<string>();
            SqlConnection dbCon = new SqlConnection(
                 @"Server=(localdb)\MSSQLLocalDB; " +
                 "Database=MinionsDB; " +
                 "Integrated Security=true");
            dbCon.Open();
            using (dbCon)
            {
                SqlCommand com = new SqlCommand("SELECT Name FROM Minions" , dbCon);
                SqlDataReader readMinionsName = com.ExecuteReader();
                using (readMinionsName)
                {
                    while (readMinionsName.Read())
                    {
                        list.Add((string)readMinionsName[0]);
                    }
                }
            }
            if(list.Count % 2== 0) {
                for (int i = 0; i < list.Count/2; i++)
                {
                    listOrdered.Add(list[i]);
                    listOrdered.Add(list[list.Count-1-i]);
                }
            }else {
                for (int i = 0; i < list.Count / 2; i++)
                {
                    listOrdered.Add(list[i]);
                    listOrdered.Add(list[list.Count - 1 - i]);
                }
                listOrdered.Add(list[list.Count / 2]);
            }
            foreach (var item in listOrdered)
            {
                Console.WriteLine(item);
            }
        }
    }
}
