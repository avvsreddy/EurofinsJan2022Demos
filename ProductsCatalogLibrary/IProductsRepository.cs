using ProductsCatalogLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsCatalogLibrary
{
    public interface IProductsRepository
    {
        Product SaveProduct(Product productToSave);
        Product GetProduct(int id);
        List<Product> GetProducts();
        int EditProduct(Product productToEdit);
        int DeleteProduct(int id);
    }
}
