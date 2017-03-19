using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftuniDatabaseProblems
{
    class Startup
    {
        static void Main(string[] args)
        {
            var context = new SoftuniContext();
            using (context)
            {
                Console.WriteLine("----------------- Problem.17 -----------------");
                //17. Call a Stored Procedure
                CallStoredProcedure(context);

                Console.WriteLine("----------------- Problem.18 -----------------");
                //18. Employees Maximum Salaries
                EmployeesMaximumSalary(context);
            }
        }
        private static void CallStoredProcedure(SoftuniContext context)
        {
            string[] names = Console.ReadLine().Split(' ');
            SqlParameter firstname = new SqlParameter("@FirstName", names[0]);
            SqlParameter lastname = new SqlParameter("@LastName", names[1]);
            var result=context.Database.SqlQuery<int>("Employee_Projects @FirstName,@LastName", firstname,lastname).ToList();
            var projects = context.Projects.Where(p => result.Contains(p.ProjectID));
            foreach (var project in projects)
            {
                Console.WriteLine($"{project.Name} - {project.Description.Substring(0,30)}..., {project.StartDate}");
            }
        }
        private static void EmployeesMaximumSalary(SoftuniContext context)
        {
            var departments = context.Departments;
            foreach (var department in departments)
            {
                var maxsalary = department.Employees.Where(d=>d.Department.Name==department.Name).Max(e => e.Salary);
                if (maxsalary<30000 || maxsalary>70000)
                {
                    Console.WriteLine($"{department.Name} - {maxsalary}");
                }
            }
        }
    }
}
