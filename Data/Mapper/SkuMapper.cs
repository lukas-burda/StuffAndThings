using StuffAndThings.Data.Entities;
using StuffAndThings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffAndThings.Data.Mapper
{
    public class SkuMapper
    {
        public static SkuEntity Mapper(SkuModel sModel)
        {
            SkuEntity sEntity = new SkuEntity
            {
                Id = sModel.Id,
                Name = sModel.Name,
                Price = sModel.Price,
                Color = sModel.Color,
                Barcode = sModel.Barcode,
                ProductEntityId = sModel.ProductId
            };
            return sEntity;
        }

        public static SkuModel Mapper(SkuEntity sEntity)
        {
            SkuModel sModel = new SkuModel
            {
                Barcode = sEntity.Barcode,
                Color = sEntity.Color,
                Id = sEntity.Id,
                Name = sEntity.Name,
                Price = sEntity.Price,
                ProductId = sEntity.ProductEntityId
            };
            return sModel;
        }

        public static List<SkuEntity> Mapper(List<SkuModel> smList)
        {
            List<SkuEntity> seList = new List<SkuEntity>();
            foreach (var sm in smList)
            {
                SkuEntity sEntity = new SkuEntity
                {
                    Id = sm.Id,
                    Name = sm.Name,
                    Price = sm.Price,
                    Color = sm.Color,
                    Barcode = sm.Barcode,
                    ProductEntityId = sm.ProductId
                };

                seList.Add(sEntity);
            }
            
            return seList;
        }

        public static List<SkuModel> Mapper(List<SkuEntity> seList)
        {
            List<SkuModel> smList = new List<SkuModel>();
            foreach (var se in seList)
            {
                SkuModel sModel = new SkuModel
                {
                    Barcode = se.Barcode,
                    Color = se.Color,
                    Id = se.Id,
                    Name = se.Name,
                    Price = se.Price,
                    ProductId = se.ProductEntityId
                };
                smList.Add(sModel);
            }
            
            return smList;
        }
    }
}
