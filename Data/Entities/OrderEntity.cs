using StuffAndThings.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffAndThings.Data.Entities
{
    public class OrderEntity
    {
        public Guid Id { get; set; }
        public string FriendlyCode { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public double Total { get; set; }
        public double SubTotal { get; set; }
        public double Discount { get; set; }
        public string Message { get; set; }
        public UserEntity Seller { get; set; }
        public List<SkuEntity> Items { get; set; }
        public OrderStatus Status { get; set; }
        public OrderEntity()
        {
            Items = new List<SkuEntity>();
        }
    }
}
