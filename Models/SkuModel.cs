using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffAndThings.Models
{
    public class SkuModel
    { 
        public Guid Id { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }
        public int AvailableQuantity { get; set; }
    }
}
