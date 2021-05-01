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
            ProductEntity pEntity = new ProductEntity
            {
                Id = pModel.Id,
                Code = pModel.Code,
                Description = pModel.Description,
                ImageUrl = pModel.ImageUrl,
                Name = pModel.Name
            };
            foreach (var item in pModel.Skus) pEntity.Skus.Add(SkuMapper.Mapper(item));
            return pEntity;
        }
        public static ProductModel Mapper(ProductEntity pEntity)
        {
            ProductModel pModel = new ProductModel
            {
                Id = pEntity.Id,
                Code = pEntity.Code,
                Description = pEntity.Description,
                ImageUrl = pEntity.ImageUrl,
                Name = pEntity.Name
            };
            foreach (var item in pEntity.Skus) pModel.Skus.Add(SkuMapper.Mapper(item));
            return pModel;
        }
    }
}
