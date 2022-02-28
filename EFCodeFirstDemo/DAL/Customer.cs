using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstDemo.DAL
{
    //[Table("Customers")] // TPT
    public class Customer : Person
    {
        public string CustType { get; set; }
        public int Discount { get; set; }
    }
}
