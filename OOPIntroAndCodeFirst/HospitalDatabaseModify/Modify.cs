using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDatabaseModify
{
    class Modify
    {
        static void Main(string[] args)
        {
            var context = new HospitalContext();
            context.Database.Delete();
            context.Database.Initialize(true);
            context.SaveChanges();
        }
    }
}
