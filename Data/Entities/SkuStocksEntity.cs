using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffAndThings.Data.Entities
{
    public class SkuStocksEntity
    {
        public Guid Id { get; set; }
        public int AvailableQuantity { get; set; }
        public UserEntity Seller { get; set; }
        public SkuEntity Sku { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
