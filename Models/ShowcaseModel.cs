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
        public virtual string ShowCaseSkuCodes { get; set; }
        public virtual List<SkuModel> Skus { get; set; }
        public DateTime LastUpdate { get; set; }
        public ShowcaseModel()
        {
            ShowcaseSkus = new List<ShowcaseSkusModel>();
            Skus = new List<SkuModel>();
        }
    }
}
