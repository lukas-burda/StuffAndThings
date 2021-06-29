using StuffAndThings.Data.Entities;
using StuffAndThings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffAndThings.Data.Mapper
{
    public class PaymentMapper
    {
        public static PaymentModel Mapper(PaymentEntity paymentEntity)
        {
            if(paymentEntity != null)
            {
                PaymentModel paymentModel = new PaymentModel
                {
                    Id = paymentEntity.Id,
                    Method = paymentEntity.Method,
                    Status = paymentEntity.Status
                };
                return paymentModel;
            }
            return null;
        }

        public static PaymentEntity Mapper(PaymentModel paymentModel)
        {
            if(paymentModel != null)
            {
                PaymentEntity paymentEntity = new PaymentEntity
                {
                    Id = paymentModel.Id,
                    Method = paymentModel.Method,
                    Status = paymentModel.Status
                };
                return paymentEntity;
            }
            return null;
        }
    }
}
