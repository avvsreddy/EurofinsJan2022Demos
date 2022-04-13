using CoolProducts.API.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CoolProducts.API.Models.Data
{
    public class CoolProductsDbContext : DbContext
    {
        public CoolProductsDbContext():base("name=DefaultConnection")
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}