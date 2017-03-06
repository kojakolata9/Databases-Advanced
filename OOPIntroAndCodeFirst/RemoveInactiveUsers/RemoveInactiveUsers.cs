using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveInactiveUsers
{
    class RemoveInactiveUsers
    {
        static void Main(string[] args)
        {
            DateTime date = Convert.ToDateTime(Console.ReadLine());
            var context = new UserContext();
            var users = context.Users.Where(u => u.LastTimeLoggedIn < date);
            int index = 0;
            foreach (var u in users)
            {
                u.IsDeleted = true;
                index += 1;
               
            }
            if (index==0)
            {
                Console.WriteLine("No users have been deleted");
            }else {
                Console.WriteLine($"{index} users have been deleted");
            }
            context.SaveChanges();
        }
    }
}
