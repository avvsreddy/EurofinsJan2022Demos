using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstDemo.DAL
{

    //[Table("Suppliers")] // TPT
    public class Supplier : Person
    {
        virtual public List<Product> Products { get; set; } = new List<Product>();

        public Address Address { get; set; }

    }
}
