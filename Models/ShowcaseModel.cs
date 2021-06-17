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
        public List<ShowcaseItemsModel> ShowcaseItems { get; set; }
        public virtual string ShowCaseItemCodes { get; set; }
        public virtual List<SkuModel> Skus { get; set; }
        public DateTime LastUpdate { get; set; }
        public ShowcaseModel()
        {
            ShowcaseItems = new List<ShowcaseItemsModel>();
            Skus = new List<SkuModel>();
        }
    }
}
