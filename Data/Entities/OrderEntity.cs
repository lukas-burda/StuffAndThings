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
        public double Total { get; set; }
        public double SubTotal { get; set; }
        public double Discount { get; set; }
        public virtual UserEntity Buyer { get; set; }
        public virtual UserEntity Seller { get; set; }
        public Guid BuyerId { get; set; }
        public Guid SellerId { get; set; }
    }
}
