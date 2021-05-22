using StuffAndThings.Data.Entities;
using StuffAndThings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffAndThings.Data.Mapper
{
    public class ShowCaseMapper
    {
        public static ShowcaseEntity Mapper(ShowcaseModel scm)
        {
            ShowcaseEntity sce = new ShowcaseEntity
            {
                Id = scm.Id,
                Name = scm.Name,
                StartDate = scm.StartDate,
                EndDate = scm.EndDate,
                LastUpdate = scm.LastUpdate                
            };

            return sce;
        }

        public static ShowcaseModel Mapper(ShowcaseEntity sce)
        {
            ShowcaseModel scm = new ShowcaseModel
            {
                Id = sce.Id,
                Name = sce.Name,
                LastUpdate = sce.LastUpdate,
                EndDate = sce.EndDate,
                StartDate = sce.StartDate,
            };

            return scm;
        }

        public static List<ShowcaseEntity> Mapper(List<ShowcaseModel> scmList)
        {
            List<ShowcaseEntity> sceList = new List<ShowcaseEntity>();
            foreach (var scm in scmList)
            {
                ShowcaseEntity sce = new ShowcaseEntity
                {
                    Id = scm.Id,
                    Name = scm.Name,
                    StartDate = scm.StartDate,
                    EndDate = scm.EndDate,
                    LastUpdate = scm.LastUpdate
                };

                sceList.Add(sce);
            }

            return sceList;
        }

        public static List<ShowcaseModel> Mapper(List<ShowcaseEntity> sceList)
        {
            List<ShowcaseModel> scmList = new List<ShowcaseModel>();
            foreach (var sce in sceList)
            {
                ShowcaseModel scm = new ShowcaseModel
                {
                    Id = sce.Id,
                    Name = sce.Name,
                    LastUpdate = sce.LastUpdate,
                    EndDate = sce.EndDate,
                    StartDate = sce.StartDate,
                };

                scmList.Add(scm);
            }
            
            return scmList;
        }
    }
}
