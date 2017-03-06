using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldestFamilyMember
{
    class OldestFamilyMember
    {
        static void Main(string[] args)
        {
            Family f = new Family();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] arr = Console.ReadLine().Split(' ');
                Person p = new Person(arr[0], int.Parse(arr[1]));
                f.AddMember(p);
            }
            
            Console.WriteLine(f.GetOldestMember().Name+"  "+f.GetOldestMember().Age);
        }
        public class Person
        {
            public Person(string name, int age)
            {
                this.Name = name;
                this.Age = age;
            }
            public string Name { get; set; }
            public int Age { get; set; }
        }
        public class Family {
            private List<Person> members { get; set; }
            public Family()
            {
                members = new List<Person>();
            }
            public virtual void AddMember(Person member) {
                members.Add(member);
            }
            public virtual Person GetOldestMember() {
                List<Person> list = members;
                int max = int.MinValue;
                foreach (var item in list)
                {
                    if(max<item.Age) {
                        max = item.Age;
                    }
                }
                Person p = list.Find(e => e.Age == max);
                return p;
            }
        }
    }
}
