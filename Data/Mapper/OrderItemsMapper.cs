using StuffAndThings.Data.Entities;
using StuffAndThings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffAndThings.Data.Mapper
{
    public class OrderItemsMapper
    {
        public static OrderItemsModel Mapper(OrderItemsEntity oie)
        {
            if (oie != null)
            {
                OrderItemsModel oim = new OrderItemsModel
                {
                    Id = oie.Id,
                    Quantity = oie.Quantity,
                    Seller = UserMapper.Mapper(oie.Seller),
                    Sku = SkuMapper.Mapper(oie.Sku),
                    Order = OrderMapper.Mapper(oie.Order)
                };

                return oim;
            }
            return null;
        }

        public static OrderItemsEntity Mapper(OrderItemsModel oim)
        {
            if (oim != null)
            {
                OrderItemsEntity oie = new OrderItemsEntity
                {
                    Id = oim.Id,
                    Quantity = oim.Quantity,
                    SellerId = oim.Seller.Id,
                    SkuId = oim.Sku.Id,
                    OrderId = oim.Order.Id
                };
                return oie;
            }
            return null;
        }

        public static List<OrderItemsModel> Mapper(List<OrderItemsEntity> oieList)
        {
            if (oieList != null)
            {
                List<OrderItemsModel> oimList = new List<OrderItemsModel>();
                foreach (var oie in oieList)
                {
                    OrderItemsModel oim = new OrderItemsModel
                    {
                        Id = oie.Id,
                        Quantity = oie.Quantity,
                        Seller = UserMapper.Mapper(oie.Seller),
                        Sku = SkuMapper.Mapper(oie.Sku),
                        Order = OrderMapper.Mapper(oie.Order)
                    };

                    oimList.Add(oim);
                };

                return oimList;
            }
            return null;
        }

        public static List<OrderItemsEntity> Mapper(List<OrderItemsModel> oimList)
        {
            if (oimList != null)
            {
                List<OrderItemsEntity> oieList = new List<OrderItemsEntity>();
                foreach (var oim in oimList)
                {
                    OrderItemsEntity oie = new OrderItemsEntity
                    {
                        Id = oim.Id,
                        Quantity = oim.Quantity,
                        SellerId = oim.Seller.Id,
                        SkuId = oim.Sku.Id,
                        OrderId = oim.Order.Id
                    };

                    oieList.Add(oie);
                };

                return oieList;
            }
            return null;
        }
    }
}
