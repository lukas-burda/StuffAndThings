using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffAndThings.Models
{
    public class CartModel
    {
        public Guid Id { get; set; }
        public List<ProductModel> Products { get; set; }
        public List<SkuModel> Skus { get; set; }
        public UserModel Buyer { get; set; }
        public UserModel Seller { get; set; }
        public double TotalValue { get; set; }
        public double SubTotalValue { get; set; }
        public double DiscountValue { get; set; }
        public double FreightValue { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
