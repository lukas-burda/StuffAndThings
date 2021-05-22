using StuffAndThings.Data.Entities;
using StuffAndThings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffAndThings.Data.Mapper
{
    public class ShowCaseProductsMapper
    {
        public static ShowcaseProductsModel Mapper(ShowcaseProductsEntity sce)
        {
            ShowcaseProductsModel scm = new ShowcaseProductsModel
            {
                Id = sce.Id,
                Product = ProductMapper.Mapper(sce.Product),
                ShowCase = ShowCaseMapper.Mapper(sce.ShowCase)
            };

            return scm;
        }

        public static ShowcaseProductsEntity Mapper(ShowcaseProductsModel scm)
        {
            ShowcaseProductsEntity sce = new ShowcaseProductsEntity
            {
                Id = scm.Id,
                ProductId = scm.Product.Id,
                ShowCaseId = scm.ShowCase.Id
            };

            return sce;
        }

        public static List<ShowcaseProductsModel> Mapper(List<ShowcaseProductsEntity> sceList)
        {
            List<ShowcaseProductsModel> scmList = new List<ShowcaseProductsModel>();
            foreach (var sce in sceList)
            {
                ShowcaseProductsModel scm = new ShowcaseProductsModel
                {
                    Id = sce.Id,
                    Product = ProductMapper.Mapper(sce.Product),
                    ShowCase = ShowCaseMapper.Mapper(sce.ShowCase)
                };

                scmList.Add(scm);
            }

            return scmList;
        }

        public static List<ShowcaseProductsEntity> Mapper(List<ShowcaseProductsModel> scmList)
        {
            List<ShowcaseProductsEntity> sceList = new List<ShowcaseProductsEntity>();
            foreach (var scm in scmList)
            {
                ShowcaseProductsEntity sce = new ShowcaseProductsEntity
                {
                    Id = scm.Id,
                    ProductId = scm.Product.Id,
                    ShowCaseId = scm.ShowCase.Id
                };

                sceList.Add(sce);
            }
            

            return sceList;
        }
    }
}
