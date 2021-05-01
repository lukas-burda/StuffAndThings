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
                Message = oEntity.Message,
                Buyer = UserMapper.Mapper(oEntity.Buyer),
                Seller = UserMapper.Mapper(oEntity.Seller),
                Status = oEntity.Status,
                Type = oEntity.Type,
                SubTotal = oEntity.SubTotal,
                Total = oEntity.SubTotal,

            };
            foreach (var prod in oEntity.Products) oModel.Products.Add(ProductMapper.Mapper(prod));
            foreach (var sku in oEntity.Skus) oModel.Skus.Add(SkuMapper.Mapper(sku));
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
                Message = oModel.Message,
                BuyerId = oModel.Buyer.Id,
                SellerId = oModel.Seller.Id,
                Status = oModel.Status,
                SubTotal = oModel.SubTotal,
                Total = oModel.Total
            };
            foreach (var prod in oModel.Products) oEntity.Products.Add(ProductMapper.Mapper(prod));
            foreach (var sku in oModel.Skus) oEntity.Skus.Add(SkuMapper.Mapper(sku));
            return oEntity;
        }
    }
}
