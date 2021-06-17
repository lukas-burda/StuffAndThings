using StuffAndThings.Data.Entities;
using StuffAndThings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffAndThings.Data.Mapper
{
    public class ShowcaseItemsMapper
    {
        public static ShowcaseItemsModel Mapper(ShowcaseSkusEntity sce)
        {
            ShowcaseItemsModel scm = new ShowcaseItemsModel
            {
                Id = sce.Id,
                Sku = SkuMapper.Mapper(sce.Sku),
                ShowCase = ShowcaseMapper.Mapper(sce.ShowCase)
            };

            return scm;
        }

        public static ShowcaseSkusEntity Mapper(ShowcaseItemsModel scm)
        {
            ShowcaseSkusEntity sce = new ShowcaseSkusEntity
            {
                Id = scm.Id,
                SkuId = scm.Sku.Id,
                ShowCaseId = scm.ShowCase.Id
            };

            return sce;
        }

        public static List<ShowcaseItemsModel> Mapper(List<ShowcaseSkusEntity> sceList)
        {
            List<ShowcaseItemsModel> scmList = new List<ShowcaseItemsModel>();
            foreach (var sce in sceList)
            {
                ShowcaseItemsModel scm = new ShowcaseItemsModel
                {
                    Id = sce.Id,
                    Sku = SkuMapper.Mapper(sce.Sku),
                    ShowCase = ShowcaseMapper.Mapper(sce.ShowCase)
                };

                scmList.Add(scm);
            }

            return scmList;
        }

        public static List<ShowcaseSkusEntity> Mapper(List<ShowcaseItemsModel> scmList)
        {
            List<ShowcaseSkusEntity> sceList = new List<ShowcaseSkusEntity>();
            foreach (var scm in scmList)
            {
                ShowcaseSkusEntity sce = new ShowcaseSkusEntity
                {
                    Id = scm.Id,
                    SkuId = scm.Sku.Id,
                    ShowCaseId = scm.ShowCase.Id
                };

                sceList.Add(sce);
            }
            

            return sceList;
        }
    }
}
