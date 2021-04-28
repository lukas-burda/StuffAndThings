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
            SkuEntity sEntity = new SkuEntity();
            sEntity.Id = sModel.Id;
            sEntity.Name = sModel.Name;
            sEntity.Price = sModel.Price;
            sEntity.Color = sModel.Color;
            sEntity.Barcode = sModel.Barcode;
            return sEntity;
        }

        public static SkuModel Mapper(SkuEntity sEntity)
        {
            SkuModel sModel = new SkuModel();
            sModel.Barcode = sEntity.Barcode;
            sModel.Color = sEntity.Color;
            sModel.Id = sEntity.Id;
            sModel.Name = sEntity.Name;
            sModel.Price = sEntity.Price;
            return sModel;
        }
    }
}
