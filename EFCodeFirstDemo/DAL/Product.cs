using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstDemo.DAL
{
    // POCO - Entity Class - Domain Class
   
    public class Product
    {
        //[Key]
        public int ProductID { get; set; }
        //[Required]
        public string Name { get; set; }
        public int Price { get; set; }
        public bool IsInStock { get; set; }
        virtual public  Catagory Catagory { get; set; }

        virtual public List<Supplier> Suppliers { get; set; } = new List<Supplier>();
    }
}
