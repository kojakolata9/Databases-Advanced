using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    class Students
    {
        static void Main(string[] args)
        {
            string line= Console.ReadLine();
            while (line!="End") {
                Student x = new Student(line);
                line = Console.ReadLine();
            }
            Console.WriteLine(Student.Integer);
            
        }
        public class Student {
            static private int index=0;
            public string Name { get; set; }
            public Student(string name)
            {
                this.Name = name;
                index++;
            }            
            static public int Integer { get { return index; } }
        }
    }
}
