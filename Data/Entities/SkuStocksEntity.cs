using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StuffAndThings.Data.Entities
{
    public class SkuStocksEntity
    {
        public Guid Id { get; set; }
        public int AvailableQuantity { get; set; }
        [ForeignKey("SellerId")]
        public UserEntity Seller { get; set; }
        [ForeignKey("SkuId")]
        public SkuEntity Sku { get; set; }
        public DateTime LastUpdate { get; set; }
        public Guid SellerId { get; set; }
        public Guid SkuId { get; set; }
    }
}
