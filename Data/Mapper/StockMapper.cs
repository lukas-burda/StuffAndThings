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
            SkuStocksModel sModel = new SkuStocksModel();
            sModel.Id = sEntity.Id;
            sModel.AvailableQuantity = sEntity.AvailableQuantity;
            sModel.LastUpdate = sEntity.LastUpdate;
            sModel.Sku = SkuMapper.Mapper(sEntity.Sku);
            sModel.Seller = UserMapper.Mapper(sEntity.Seller);
            return sModel;
        }

        public static SkuStocksEntity Mapper(SkuStocksModel sModel)
        {
            SkuStocksEntity sEntity = new SkuStocksEntity();
            sEntity.Id = sModel.Id;
            sEntity.LastUpdate = sModel.LastUpdate;
            sEntity.AvailableQuantity = sModel.AvailableQuantity;
            sEntity.SkuId = sModel.Sku.Id;
            sEntity.SellerId = sModel.Seller.Id;
            return sEntity;
        }
    }
}
