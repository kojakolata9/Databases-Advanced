using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GringottsDatabaseProblems
{
    class Startup
    {
        static void Main(string[] args)
        {
            var context = new GringottsContext();
            using (context)
            {
                Console.WriteLine("----------------- Problem.19 -----------------");
                //19. Deposits Sum for Ollivander Family
                DepositsSumForOllivanderFamily(context);

                Console.WriteLine("----------------- Problem.20 -----------------");
                //20. Deposits Filter
                DespositsFilter(context);
            }
        }
        private static void DepositsSumForOllivanderFamily(GringottsContext context)
        {
            var depositGroups = context.WizzardDeposits.Where(w => w.MagicWandCreator == "Ollivander family")
                .GroupBy(w => w.DepositGroup)
                .Select(
                    w => new {Name = w.Key, Sum = w.Sum(wd => wd.DepositAmount)});
            foreach (var d in depositGroups)
            {
                Console.WriteLine($"{d.Name} - {d.Sum}");
            }
        }
        private static void DespositsFilter(GringottsContext context)
        {
            var depositGroups = context.WizzardDeposits.Where(w => w.MagicWandCreator == "Ollivander family")
                .GroupBy(w => w.DepositGroup)
                .Select(
                    w => new { Name = w.Key, Sum = w.Sum(wd => wd.DepositAmount) }).OrderByDescending(w=>w.Sum);
            foreach (var d in depositGroups)
            {
                if (d.Sum<150000m)
                {
                    Console.WriteLine($"{d.Name} - {d.Sum}");
                }
            }
        }
    }
}
