using StuffAndThings.Data.Entities;
using StuffAndThings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffAndThings.Data.Mapper
{
    public class StockMapper
    {
        public static SkuStocksModel Mapper(SkuStocksEntity sEntity)
        {
            SkuStocksModel sModel = new SkuStocksModel
            {
                Id = sEntity.Id,
                AvailableQuantity = sEntity.AvailableQuantity,
                LastUpdate = sEntity.LastUpdate,
                Sku = SkuMapper.Mapper(sEntity.Sku),
                Seller = UserMapper.Mapper(sEntity.Seller)
            };
            return sModel;
        }

        public static SkuStocksEntity Mapper(SkuStocksModel sModel)
        {
            SkuStocksEntity sEntity = new SkuStocksEntity
            {
                Id = sModel.Id,
                LastUpdate = sModel.LastUpdate,
                AvailableQuantity = sModel.AvailableQuantity,
                SkuId = sModel.Sku.Id,
                SellerId = sModel.Seller.Id
            };
            return sEntity;
        }
    }
}
