using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StuffAndThings.Models
{
    public class SkuModel
    {
        public Guid Id { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Color { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Price { get; set; }
        public ProductModel Product { get; set; }
        public Guid ProductId { get; set; }
        [NotMapped]
        public List<ProductModel> Products { get; set; }
        public SkuModel()
        {
            Products = new List<ProductModel>();
        }
    }
}
