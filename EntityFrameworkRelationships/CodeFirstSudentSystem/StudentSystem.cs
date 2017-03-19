using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstSudentSystem
{
    class StudentSystem
    {
        static void Main(string[] args)
        {
            var context = new StudentSystemContext();
            context.Database.Initialize(true);
        }
    }
}
