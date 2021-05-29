using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffAndThings.Models
{
    public class ShowcaseSkusModel
    {
        public Guid Id { get; set; }
        public SkuModel Sku { get; set; }
        public ShowcaseModel ShowCase { get; set; }
    }
}
