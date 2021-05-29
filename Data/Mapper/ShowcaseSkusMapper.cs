using StuffAndThings.Data.Entities;
using StuffAndThings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffAndThings.Data.Mapper
{
    public class ShowcaseSkusMapper
    {
        public static ShowcaseSkusModel Mapper(ShowcaseSkusEntity sce)
        {
            ShowcaseSkusModel scm = new ShowcaseSkusModel
            {
                Id = sce.Id,
                Sku = SkuMapper.Mapper(sce.Sku),
                ShowCase = ShowCaseMapper.Mapper(sce.ShowCase)
            };

            return scm;
        }

        public static ShowcaseSkusEntity Mapper(ShowcaseSkusModel scm)
        {
            ShowcaseSkusEntity sce = new ShowcaseSkusEntity
            {
                Id = scm.Id,
                SkuId = scm.Sku.Id,
                ShowCaseId = scm.ShowCase.Id
            };

            return sce;
        }

        public static List<ShowcaseSkusModel> Mapper(List<ShowcaseSkusEntity> sceList)
        {
            List<ShowcaseSkusModel> scmList = new List<ShowcaseSkusModel>();
            foreach (var sce in sceList)
            {
                ShowcaseSkusModel scm = new ShowcaseSkusModel
                {
                    Id = sce.Id,
                    Sku = SkuMapper.Mapper(sce.Sku),
                    ShowCase = ShowCaseMapper.Mapper(sce.ShowCase)
                };

                scmList.Add(scm);
            }

            return scmList;
        }

        public static List<ShowcaseSkusEntity> Mapper(List<ShowcaseSkusModel> scmList)
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
