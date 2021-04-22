using StuffAndThings.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffAndThings.Models
{
    public class OrderModel
    {
        public Guid Id { get; set; }
        public string FriendlyCode { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public double SubTotal { get; set; } = 0;
        public double Discount { get; set; } = 0;
        public string Message { get; set; }
        public UserModel Seller { get; set; }
        public List<SkuModel> Items { get; set; }
        public OrderStatus Status { get; set; } = 0;
    }
}
