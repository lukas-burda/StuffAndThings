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
            OrderModel oModel = new OrderModel();
            oModel.CreateDate = oEntity.CreateDate;
            oModel.Discount = oEntity.Discount;
            oModel.FriendlyCode = oEntity.FriendlyCode;
            oModel.Id = oEntity.Id;
            foreach (var item in oEntity.Items) oModel.Items.Add(SkuMapper.Mapper(item));
            oModel.LastUpdate = oEntity.LastUpdate;
            oModel.Message = oEntity.Message;
            oModel.Seller = UserMapper.Mapper(oEntity.Seller);
            oModel.Status = oEntity.Status;
            oModel.Total = oEntity.Total;
            return oModel;
        }

        public static OrderEntity Mapper(OrderModel oModel)
        {
            OrderEntity oEntity = new OrderEntity();
            oEntity.Id = oModel.Id;
            oEntity.CreateDate = oModel.CreateDate;
            oEntity.Discount = oModel.Discount;
            oEntity.FriendlyCode = oModel.FriendlyCode;
            foreach (var item in oModel.Items) oEntity.Items.Add(SkuMapper.Mapper(item));
            oEntity.LastUpdate = oModel.LastUpdate;
            oEntity.Message = oModel.Message;
            oEntity.Seller = UserMapper.Mapper(oModel.Seller);
            oEntity.Status = oModel.Status;
            oEntity.SubTotal = oModel.SubTotal;
            oEntity.Total = oModel.Total;
            return oEntity;
        }
    }
}
