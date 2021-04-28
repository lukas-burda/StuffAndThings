using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffAndThings.Models
{
    public class SkuStocksModel
    {
        public Guid Id { get; set; }
        public int AvailableQuantity { get; set; }
        public UserModel Seller { get; set; }
        public SkuModel Sku { get; set; }
        public DateTime LastUpdate { get; set; }
        public List<SkuModel> Skus { get; set; }
        public List<UserModel> Sellers { get; set; }
        public SkuStocksModel()
        {
            Skus = new List<SkuModel>();
            Sellers = new List<UserModel>();
        }
    
    }
}
