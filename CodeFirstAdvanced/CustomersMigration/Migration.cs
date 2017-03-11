using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersMigration
{
    class Migration
    {
        static void Main(string[] args)
        {
            //check automatic migration
            var context = new SalesContext();
            context.Database.Initialize(true);
        }
    }
}
