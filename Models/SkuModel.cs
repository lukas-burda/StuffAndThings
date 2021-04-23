using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Price { get; set; }
    }
}
