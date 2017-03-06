using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanckConstant
{
    class PlanckConstant
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Calculation.ReturnValue());
                
        }
        public class Calculation {
            private const decimal x = 6.62606896e-34m;
            private const decimal y = 3.14159m;
            static public decimal ReturnValue() {
                return x / (2 * y);
            }
        }
    }
}
