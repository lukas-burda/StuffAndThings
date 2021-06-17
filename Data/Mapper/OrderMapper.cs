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
        public static OrderModel Mapper(OrderEntity oe)
        {
            OrderModel om = new OrderModel
            {
                CreateDate = oe.CreateDate,
                Discount = oe.Discount,
                FriendlyCode = oe.FriendlyCode,
                Id = oe.Id,
                SubTotal = oe.SubTotal,
                Total = oe.Total,
                Buyer = UserMapper.Mapper(oe.Buyer),
                Seller = UserMapper.Mapper(oe.Seller)
            };
            return om;
        }

        public static OrderEntity Mapper(OrderModel om)
        {
            OrderEntity oe = new OrderEntity
            {
                CreateDate = om.CreateDate,
                Discount = om.Discount,
                Id = om.Id,
                FriendlyCode = om.FriendlyCode,
                SubTotal = om.SubTotal,
                Total = om.Total,
                BuyerId = om.Buyer.Id,
                SellerId = om.Seller.Id
            };
            return oe;
        }

        public static List<OrderModel> Mapper(List<OrderEntity> oeList)
        {
            List<OrderModel> omList = new List<OrderModel>();
            foreach (var oe in oeList)
            {
                OrderModel om = new OrderModel
                {
                    CreateDate = oe.CreateDate,
                    Discount = oe.Discount,
                    FriendlyCode = oe.FriendlyCode,
                    Id = oe.Id,
                    SubTotal = oe.SubTotal,
                    Total = oe.Total,
                    Buyer = UserMapper.Mapper(oe.Buyer),
                    Seller = UserMapper.Mapper(oe.Seller)
                };

                omList.Add(om);
            }
            
            return omList;
        }

        public static List<OrderEntity> Mapper(List<OrderModel> omList)
        {
            List<OrderEntity> oeList = new List<OrderEntity>();
            foreach (var om in omList)
            {
                OrderEntity oe = new OrderEntity
                {
                    CreateDate = om.CreateDate,
                    Discount = om.Discount,
                    Id = om.Id,
                    FriendlyCode = om.FriendlyCode,
                    SubTotal = om.SubTotal,
                    Total = om.Total,
                    BuyerId = om.Buyer.Id,
                    SellerId = om.Seller.Id
                };

                oeList.Add(oe);
            }
            
            return oeList;
        }
    }
}
