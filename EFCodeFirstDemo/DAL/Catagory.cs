using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstDemo.DAL
{
    public class Catagory
    {
        public int CatagoryId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual List<Product> Products { get; set; } = new List<Product>();
    }
}
