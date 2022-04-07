using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductsCatalogLibrary;
using ProductsCatalogLibrary.Entities;

namespace ProductsCatalogClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IProductsRepository repo = new ProductsRepository();
            Product p = new Product { Name = "Sony J75 TV", Price = 350000, Brand = "Sony" };
            repo.SaveProduct(p);
            Console.WriteLine("The product is saved");
        }
    }
}
