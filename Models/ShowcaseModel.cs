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
        public List<ShowcaseSkusModel> ShowcaseSkus { get; set; }
        public virtual List<ProductModel> Products { get; set; }
        public DateTime LastUpdate { get; set; }
        public ShowcaseModel()
        {
            ShowcaseSkus = new List<ShowcaseSkusModel>();
            Products = new List<ProductModel>();
        }
    }
}
