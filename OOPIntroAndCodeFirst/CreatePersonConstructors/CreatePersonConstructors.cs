using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatePersonConstructors
{
    class CreatePersonConstructors
    {
        static void Main(string[] args)
        {
            Person p1 = new Person("Pesho",20);
            Person p2 = new Person("Gosho");
            Person p3 = new Person(43);
            Person p4 = new Person();
            Console.WriteLine("People");
            Console.WriteLine("------------------------------");
            Console.WriteLine("Name     |Age     |");
            Console.WriteLine("------------------------------");
            Console.WriteLine(p1.Name + new string(' ', 9 - p1.Name.Length) + "|" + p1.Age + new string(' ', 6) + "|");
            Console.WriteLine(p2.Name + new string(' ', 9 - p2.Name.Length) + "|" + p2.Age + new string(' ', 7) + "|");
            Console.WriteLine(p3.Name + new string(' ', 9 - p3.Name.Length) + "|" + p3.Age + new string(' ', 6) + "|");
            Console.WriteLine(p4.Name + new string(' ', 9 - p4.Name.Length) + "|" + p4.Age + new string(' ', 7) + "|");
        }
        public class Person {
            public Person(string name,int age) {
                this.Name = name;
                this.Age = age;
            }
            public Person() : this("No name", 1) { }
            public Person(int age) : this("No name", age) { }
            public Person(string name) : this(name, 1) { }
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}
