using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoolProducts.API.Models.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Cost { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public bool IsAvailable { get; set; }
        public double Rating { get; set; }
    }
}