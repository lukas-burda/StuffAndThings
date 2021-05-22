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

        public static List<ProductEntity> Mapper(List<ProductModel> pmList)
        {
            List<ProductEntity> peList = new List<ProductEntity>();
            foreach (var pm in pmList)
            {
                ProductEntity pEntity = new ProductEntity
                {
                    Id = pm.Id,
                    Code = pm.Code,
                    Description = pm.Description,
                    ImageUrl = pm.ImageUrl,
                    Name = pm.Name,
                    Skus = SkuMapper.Mapper(pm.Skus)
                };

                peList.Add(pEntity);
            }
            
            return peList;
        }
        public static List<ProductModel> Mapper(List<ProductEntity> peList)
        {
            List<ProductModel> pmList = new List<ProductModel>();
            foreach (var pe in peList)
            {
                ProductModel pModel = new ProductModel
                {
                    Id = pe.Id,
                    Code = pe.Code,
                    Description = pe.Description,
                    ImageUrl = pe.ImageUrl,
                    Name = pe.Name,
                    Skus = SkuMapper.Mapper(pe.Skus)
                };

                pmList.Add(pModel);
            }
            
            return pmList;
        }
    }
}
