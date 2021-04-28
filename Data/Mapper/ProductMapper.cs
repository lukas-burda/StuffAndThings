using StuffAndThings.Data.Entities;
using StuffAndThings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffAndThings.Data.Mapper
{
    public class ProductMapper
    {
        public static ProductEntity Mapper(ProductModel pModel)
        {
            ProductEntity pEntity = new ProductEntity();
            pEntity.Id = pModel.Id;
            pEntity.Code = pModel.Code;
            pEntity.Description = pModel.Description;
            pEntity.ImageUrl = pModel.ImageUrl;
            pEntity.Name = pModel.Name;
            foreach (var item in pModel.Skus) pEntity.Skus.Add(SkuMapper.Mapper(item));
            return pEntity;
        }
        public static ProductModel Mapper(ProductEntity pEntity)
        {
            ProductModel pModel = new ProductModel();
            pModel.Id = pEntity.Id;
            pModel.Code = pEntity.Code;
            pModel.Description = pEntity.Description;
            pModel.ImageUrl = pEntity.ImageUrl;
            pModel.Name = pEntity.Name;
            foreach (var item in pEntity.Skus) pModel.Skus.Add(SkuMapper.Mapper(item));
            return pModel;
        }
    }
}
