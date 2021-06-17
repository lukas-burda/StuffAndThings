using StuffAndThings.Models.Enums;
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
        public double Total { get; set; } = 0;
        public double SubTotal { get; set; } = 0;
        public double Discount { get; set; } = 0;
        public UserModel Buyer { get; set; }
        public UserModel Seller { get; set; }
        public virtual List<UserModel> Buyers { get; set; }
        public List<OrderItemsModel> OrderItems { get; set; }
        public OrderModel()
        {
            Buyers = new List<UserModel>();
            OrderItems = new List<OrderItemsModel>();
        }

    }


}
