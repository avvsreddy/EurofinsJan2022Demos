using ProductsCatalogLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsCatalogLibrary
{
    public class ProductsRepository : IProductsRepository
    {

        private ProductsDbContext db = new ProductsDbContext();
        public int DeleteProduct(int id)
        {
            var productToDel = db.Products.Find(id);
            if (productToDel == null)
                throw new Exception("Product not found");
            db.Products.Remove(productToDel);
            return db.SaveChanges();
        }

        public int EditProduct(Product productToEdit)
        {
            db.Entry(productToEdit).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }

        public Product GetProduct(int id)
        {
            var p = db.Products.Find(id);
            if (p == null)
                throw new Exception("Product not found");
            return p;

        }

        public List<Product> GetProducts()
        {
            return db.Products.ToList();
        }

        public Product SaveProduct(Product productToSave)
        {
            if (productToSave == null)
                throw new Exception("Invalid Data");
            db.Products.Add(productToSave);
            db.SaveChanges();
            return productToSave;

        }
    }
}
