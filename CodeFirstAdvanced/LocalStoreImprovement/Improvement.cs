using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalStoreImprovement
{
    class Improvement
    {
        static void Main(string[] args)
        {
            var context = new LocalStore();
            context.Database.Initialize(true);
            var product1 = new Product()
            {
                Name = "Sault",
                DistributorName = "Pepper",
                Price = 12.00m,
                Weight = 12m
            };
            var product2 = new Product()
            {
                Name = "Sugar",
                DistributorName = "Sugarland",
                Price = 13.53m,
                Weight = 12m
            };
            var product3 = new Product()
            {
                Name = "Pepper",
                DistributorName = "Pepper",
                Price = 9.45m,
                Weight=12m
            };
            context.Products.Add(product1);
            context.Products.Add(product2);
            context.Products.Add(product3);
            context.SaveChanges();
        }
    }
}
