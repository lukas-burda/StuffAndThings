using StuffAndThings.Enums;
using StuffAndThings.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StuffAndThings.Data.Entities
{
    public class OrderEntity
    {
        public Guid Id { get; set; }
        public string FriendlyCode { get; set; }
        public DateTime CreateDate { get; set; }
        public double Total { get; set; }
        public double SubTotal { get; set; }
        public double Discount { get; set; }
        public string Message { get; set; }
        public List<SkuEntity> Items { get; set; }
        public OrderStatus Status { get; set; } = 0;
        public OrderType Type { get; internal set; } = 0;
        [ForeignKey("BuyerId")]
        public virtual UserEntity Buyer { get; internal set; }
        [ForeignKey("SellerId")]
        public virtual UserEntity Seller { get; set; }
        public Guid? BuyerId { get; set; }
        public Guid? SellerId { get; set; }

        public OrderEntity()
        {
            Items = new List<SkuEntity>();
        }
    }
}
