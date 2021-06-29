using StuffAndThings.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffAndThings.Data.Entities
{
    public class PaymentEntity
    {
        public Guid Id { get; set; }
        public PaymentMethodEnum Method { get; set; }
        public PaymentStatusEnum Status { get; set; }
    }
}
