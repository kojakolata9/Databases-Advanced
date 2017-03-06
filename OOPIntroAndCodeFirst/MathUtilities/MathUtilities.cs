using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathUtilities
{
    class MathUtilities
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            while (line!="End")
            {
                Console.Write("Result: ");
                string[] arr = line.Split(' ');
                decimal num1 = decimal.Parse(arr[1]);
                decimal num2 = decimal.Parse(arr[2]);
                MathUtil x = new MathUtil();
                switch (arr[0])
                {
                    case "Sum": { Console.WriteLine(x.Sum(num1,num2)); }break;
                    case "Subtract": { Console.WriteLine(x.Subtract(num1, num2)); } break;
                    case "Multiply": { Console.WriteLine(x.Multiply(num1, num2)); } break;
                    case "Divide": { Console.WriteLine(x.Divide(num1, num2)); } break;
                    case "Percentage": { Console.WriteLine(x.Percentage(num1, num2)); } break;
                    default : { Console.WriteLine("No such function"); }break;
                }
                Console.WriteLine("--------------------");
                line = Console.ReadLine();
            }
        }
        public class MathUtil {
            public decimal Sum(decimal number1,decimal number2) {
                return 1.00m * (number1 + number2);
            }
            public decimal Subtract(decimal number1, decimal number2)
            {
                return 1.00m * (number1 - number2);
            }
            public decimal Multiply(decimal number1, decimal number2)
            {
                return 1.00m * number1 * number2;
            }
            public decimal Divide(decimal number1, decimal number2)
            {
                return 1.00m * number1 / number2;
            }
            public decimal Percentage(decimal number1, decimal number2)
            {
                return 1.00m * number1 / 100 * number2;
            }
        }
    }
}
