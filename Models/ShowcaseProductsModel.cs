using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffAndThings.Models
{
    public class ShowcaseProductsModel
    {
        public Guid Id { get; set; }
        public ProductModel Product { get; set; }
        public ShowcaseModel ShowCase { get; set; }
    }
}
