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
            throw new NotImplementedException();
        }

        public Product GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProducts()
        {
            throw new NotImplementedException();
        }

        public Product SaveProduct(Product productToSave)
        {
            throw new NotImplementedException();
        }
    }
}
