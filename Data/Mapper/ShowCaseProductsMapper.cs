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
    }
}
