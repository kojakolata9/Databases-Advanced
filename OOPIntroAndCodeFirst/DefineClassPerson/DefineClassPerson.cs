using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefineClassPerson
{
    class DefineClassPerson
    {
        static void Main(string[] args)
        {
            Person p1 = new Person() { Name="Pesho",Age=20};
            Person p2 = new Person() { Name="Gosho",Age=18};
            Person p3 = new Person() { Name="Stamat",Age=43};
            Console.WriteLine("People");
            Console.WriteLine("------------------------------");
            Console.WriteLine("Name     |Age     |");
            Console.WriteLine("------------------------------");
            Console.WriteLine(p1.Name+ new string(' ',9-p1.Name.Length)+"|"+p1.Age+ new string(' ', 6)+"|");
            Console.WriteLine(p2.Name + new string(' ', 9 - p2.Name.Length) + "|" + p2.Age + new string(' ', 6) + "|");
            Console.WriteLine(p3.Name + new string(' ', 9 - p3.Name.Length) + "|" + p3.Age + new string(' ', 6) + "|");


        }
        public class Person {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}
