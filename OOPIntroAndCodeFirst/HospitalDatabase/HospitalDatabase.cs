using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDatabase
{
    class HospitalDatabase
    {
        static void Main(string[] args)
        {
            var context = new HospitalDatabaseContext();
            context.Database.Initialize(true);
            context.SaveChanges();
        }
    }
}
