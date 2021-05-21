using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffAndThings.Models
{
    public class Showcase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate{ get; set; }
        public DateTime EndDate { get; set; }
        public List<ProductModel> products { get; set; }
        public DateTime LastUpdatae { get; set; }
        public Showcase()
        {
            products = new List<ProductModel>();
        }
        

    }
}
