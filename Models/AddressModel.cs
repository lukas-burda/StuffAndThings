using StuffAndThings.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffAndThings.Models
{
    public class AddressModel
    {
        public Guid Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public StateEnum State { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string CEP { get; set; }
        public virtual List<StateEnum> States { get; set; }

        public AddressModel()
        {
            States = new List<StateEnum>();
        }
    }
}
