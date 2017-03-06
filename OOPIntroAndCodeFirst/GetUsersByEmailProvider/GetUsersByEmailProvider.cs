using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetUsersByEmailProvider
{
    class GetUsersByEmailProvider
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            var context = new UsersContext();
            var users = context.Users.Where(u => u.Email.IndexOf(line) > 0);
            foreach (var u in users)
            {
                Console.WriteLine($"{u.Username} {u.Email}");
            }
        }
    }
}
