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

        public static List<SkuStocksModel> Mapper(List<SkuStocksEntity> seList)
        {
            List<SkuStocksModel> smList = new List<SkuStocksModel>();
            foreach (var se in seList)
            {
                SkuStocksModel sModel = new SkuStocksModel
                {
                    Id = se.Id,
                    AvailableQuantity = se.AvailableQuantity,
                    LastUpdate = se.LastUpdate,
                    Sku = SkuMapper.Mapper(se.Sku),
                    Seller = UserMapper.Mapper(se.Seller)
                };

                smList.Add(sModel);
            }
            
            return smList;
        }

        public static List<SkuStocksEntity> Mapper(List<SkuStocksModel> smList)
        {
            List<SkuStocksEntity> seList = new List<SkuStocksEntity>();
            foreach (var sm in smList)
            {
                SkuStocksEntity sEntity = new SkuStocksEntity
                {
                    Id = sm.Id,
                    LastUpdate = sm.LastUpdate,
                    AvailableQuantity = sm.AvailableQuantity,
                    SkuId = sm.Sku.Id,
                    SellerId = sm.Seller.Id
                };

                seList.Add(sEntity);
            }
            
            return seList;
        }
    }
}
