using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateUser
{
    class CreateUser
    {
        static void Main(string[] args)
        {
            var context = new GringottsDatabaseContext();
            context.Database.Initialize(true);
            context.SaveChanges();
        }
    }
}
