using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffAndThings.Models
{
    public class ShowcaseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate{ get; set; }
        public DateTime EndDate { get; set; }
        public List<ProductModel> Products { get; set; }
        public List<ShowcaseProductsModel> ShowcaseProducts { get; set; }
        public DateTime LastUpdate { get; set; }
        public ShowcaseModel()
        {
            ShowcaseProducts = new List<ShowcaseProductsModel>();
            Products = new List<ProductModel>();
        }
        

    }
}
