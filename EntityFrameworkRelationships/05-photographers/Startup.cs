using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_photographers
{
    class Startup
    {
        static void Main(string[] args)
        {
            var context = new PhotographersContext();
            context.Database.Initialize(true);
        }
    }
}
