using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstDemo.DAL
{
    internal class ProductsDB : DbContext
    {
        public ProductsDB() : base("name=test")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Catagory> Catagories { get; set; }
        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            // Fluent API

            //modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired();
            //modelBuilder.Entity<Product>().HasKey(e => e.ItemID);

            // Map SP's from Product Entity

            //modelBuilder.Entity<Product>().MapToStoredProcedures();

            // Create and Map SP's for all entities

            modelBuilder.Types().Configure(t => t.MapToStoredProcedures());

            // Fluent API code for Configuring TPC

            modelBuilder.Entity<Customer>().Map(m =>
            {
                m.ToTable("Customers");
                m.MapInheritedProperties();
            }
            );

            modelBuilder.Entity<Supplier>().Map(m =>
            {
                m.ToTable("Suppliers");
                m.MapInheritedProperties();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
