using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GringottsDatabase.Models;

namespace Gringotts
{
    class GringottsDatabase
    {
        static void Main(string[] args)
        {
            var context = new GringottsModel();
            context.Database.Initialize(true);
            context.WizardDeposits.Add(new WizardDeposit()
            {

                FirstName = "Albus",
                LastName = "Dumbledore",
                Age = 150,
                MagicWandCreator = "Antioch Peverell",
                MagicWandSize = 15,
                DepositStartDate = new DateTime(2016, 10, 20),
                DepositExpirationDate = new DateTime(2020, 10, 20),
                DepositAmount = 20000.24,
                DepositCharge = 0.2,
                IsDepositExpired = false,
            });
            context.WizardDeposits.Add(new WizardDeposit()
            {

                FirstName = "Harry",
                LastName = "Poter",
                Age = 12,
                MagicWandCreator = "Grifindor",
                MagicWandSize = 15,
                DepositStartDate = new DateTime(2016, 10, 20),
                DepositExpirationDate = new DateTime(2020, 10, 20),
                DepositAmount = 20000.24,
                DepositCharge = 0.2,
                IsDepositExpired = false,
            });
            context.WizardDeposits.Add(new WizardDeposit()
            {

                FirstName = "Malko",
                LastName = "kote",
                Age = 1,
                MagicWandCreator = "q kaji",
                MagicWandSize = 15,
                DepositStartDate = new DateTime(2016, 10, 20),
                DepositExpirationDate = new DateTime(2020, 10, 20),
                DepositAmount = 20000.24,
                DepositCharge = 0.2,
                IsDepositExpired = false,
            });
            context.SaveChanges();
        }
    }
}
