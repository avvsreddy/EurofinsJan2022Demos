using ProductsCatalogLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsCatalogLibrary
{
    internal class ProductsDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
