using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoCDemoWebApplication.Models
{
    public interface IProductsRepo
    {
        List<string> GetProducts();
    }
}
