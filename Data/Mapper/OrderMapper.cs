using StuffAndThings.Data.Entities;
using StuffAndThings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffAndThings.Data.Mapper
{
    public class OrderMapper
    {
        public static OrderModel Mapper(OrderEntity oEntity)
        {
            OrderModel oModel = new OrderModel
            {
                CreateDate = oEntity.CreateDate,
                Discount = oEntity.Discount,
                FriendlyCode = oEntity.FriendlyCode,
                Id = oEntity.Id,
                LastUpdate = oEntity.LastUpdate,
                Message = oEntity.Message,
                OrderPeson = UserMapper.Mapper(oEntity.OrderPerson),
                Status = oEntity.Status,
                Type = oEntity.Type,
                SubTotal = oEntity.SubTotal,
                Total = oEntity.SubTotal,

            };
            foreach (var item in oEntity.Items) oModel.Items.Add(SkuMapper.Mapper(item));
            return oModel;
        }

        public static OrderEntity Mapper(OrderModel oModel)
        {
            OrderEntity oEntity = new OrderEntity
            {
                Id = oModel.Id,
                CreateDate = oModel.CreateDate,
                Discount = oModel.Discount,
                FriendlyCode = oModel.FriendlyCode,
                LastUpdate = oModel.LastUpdate,
                Message = oModel.Message,
                OrderPerson = UserMapper.Mapper(oModel.OrderPeson),
                Status = oModel.Status,
                SubTotal = oModel.SubTotal,
                Total = oModel.Total
            };
            foreach (var item in oModel.Items) oEntity.Items.Add(SkuMapper.Mapper(item));
            return oEntity;
        }
    }
}
