using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_working_with_database
{
    class WorkingWithDatabase
    {
        static void Main(string[] args)
        {           
            
            var context = new StudentsSystemContaxt();
            Console.WriteLine("1.Task");
            Console.WriteLine("-----------------------------------");
            foreach (var item in context.Homework)
            {
                Console.WriteLine($"{item.Student.Name}  {item.Content}");
            }
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("2.Task");
            Console.WriteLine("-----------------------------------");
            foreach (var item in context.Resources)
            {
                Console.WriteLine($"{item.Cours.Name}  {item.Name}");
            }
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("3.Task");
            Console.WriteLine("-----------------------------------");
            foreach (var item in context.Courses.Where(c=>c.Resources.Count>=5).OrderByDescending(c=>c.Resources.Count).ThenByDescending(c=>c.StartDate))
            {
                Console.WriteLine($"{item.Name}  {item.Resources.Count}");
            }
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("4.Task");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Insert a date:");
            DateTime date = Convert.ToDateTime(Console.ReadLine());
            foreach (var item in context.Courses.Where(c=>c.StartDate>=date).OrderByDescending(c=>c.Students.Count).ThenByDescending(c=>c.EndDate.Day-c.StartDate.Day))
            {
                Console.WriteLine($"{item.Name}-{item.StartDate}-{item.EndDate}-{item.EndDate.Day - item.StartDate.Day}-{item.Students.Count}");
            }
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("5.Task");
            Console.WriteLine("-----------------------------------");
            foreach (var item in context.Students.OrderByDescending(s=>s.Courses.Sum(e=>e.Price)).ThenByDescending(s=>s.Courses.Count).ThenBy(s=>s.Name))
            {
                Console.WriteLine($"{item.Name} - {item.Courses.Count} - {item.Courses.Sum(c=>c.Price)} - {item.Courses.Sum(c=>c.Price)/item.Courses.Count}");
            }
            Console.WriteLine("-----------------------------------");
        }
    }
}
