using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffAndThings.Models
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Code { get; set; }
        public List<SkuModel> Skus { get; set; }
        public List<ProductModel> Products { get; set; }

        public ProductModel()
        {
            Skus = new List<SkuModel>();
            Products = new List<ProductModel>();
        }
    }
}
