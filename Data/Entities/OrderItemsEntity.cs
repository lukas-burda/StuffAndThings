using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StuffAndThings.Data.Entities
{
    public class OrderItemsEntity
    {
        public Guid Id { get; set; }
        [ForeignKey("SkuId")]
        public virtual SkuEntity Sku { get; set; }
        [ForeignKey("SellerId")]
        public virtual UserEntity Seller { get; set; }
        [ForeignKey("OrderId")]
        public virtual OrderEntity Order { get; set; }
        public int Quantity { get; set; }
        public Guid SkuId { get; set; }
        public Guid SellerId { get; set; }
        public Guid OrderId { get; set; }
    }
}
