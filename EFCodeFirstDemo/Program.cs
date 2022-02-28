using EFCodeFirstDemo.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // want to manage products
            // Create product
            ProductsDB db = new ProductsDB();
            db.Database.Log = Console.WriteLine;

            

        }
    }
}
