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
    }
}
