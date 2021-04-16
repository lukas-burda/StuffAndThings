using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffAndThings.Data.Entities
{
    public class StockEntity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public int AvailableQuantity { get; set; }
        public Guid SellerId { get; set; }
        public Guid SkuId { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
