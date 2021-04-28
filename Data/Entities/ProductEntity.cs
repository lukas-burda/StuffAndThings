using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffAndThings.Data.Entities
{
    public class ProductEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Code { get; set; }
        public List<SkuEntity> Skus { get; set; }
        public ProductEntity()
        {
            Skus = new List<SkuEntity>();
        }
    }
}
