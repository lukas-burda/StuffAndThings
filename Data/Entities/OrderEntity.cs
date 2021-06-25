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
        [ForeignKey("BuyerId")]
        public virtual UserEntity Buyer { get; set; }
        [ForeignKey("SellerId")]
        public virtual UserEntity Seller { get; set; }
        [ForeignKey("AddressId")]
        public virtual AddressEntity Address { get; set; }
        public Guid? BuyerId { get; set; }
        public Guid? SellerId { get; set; }
        public Guid? AddressId { get; set; }
    }
}
