using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffAndThings.Models
{
    public class OrderItemsModel
    {
        public Guid Id { get; set; }
        public SkuModel Sku { get; set; }
        public UserModel Seller { get; set; }
        public OrderModel Order { get; set; }
        public int Quantity { get; set; }
    }
}
