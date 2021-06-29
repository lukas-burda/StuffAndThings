using StuffAndThings.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffAndThings.Models
{
    public class PaymentModel
    {
        public Guid Id { get; set; }
        public PaymentMethodEnum Method { get; set; }
        public PaymentStatusEnum Status { get; set; }

        public string NameOnCard { get; set; } = null;
        public string CardNumbers { get; set; } = null;
        public string Expiration { get; set; } = null;
        public string CVV { get; set; } = null;

    }

}
