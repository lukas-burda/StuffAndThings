using StuffAndThings.Data.Entities;
using StuffAndThings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffAndThings.Data.Mapper
{
    public class UserMapper
    {
        public static UserEntity Mapper(UserModel uModel)
        {
            UserEntity uEntity = new UserEntity
            {
                Document = uModel.Document,
                Discriminator = uModel.Discriminator,
                FullName = uModel.FullName,
                Id = uModel.Id
            };
            return uEntity;
        }

        public static UserModel Mapper(UserEntity uEntity)
        {
            UserModel uModel = new UserModel
            {
                Id = uEntity.Id,
                Document = uEntity.Document,
                FullName = uEntity.FullName,
                Discriminator = uEntity.Discriminator,
            };
            return uModel;
        }

        public static List<UserEntity> Mapper(List<UserModel> umList)
        {
            List<UserEntity> ueList = new List<UserEntity>();
            foreach (var um in umList)
            {
                UserEntity uEntity = new UserEntity
                {
                    Document = um.Document,
                    Discriminator = um.Discriminator,
                    FullName = um.FullName,
                    Id = um.Id
                };

                ueList.Add(uEntity);
            }
            
            return ueList;
        }

        public static List<UserModel> Mapper(List<UserEntity> ueList)
        {
            List<UserModel> umList = new List<UserModel>();
            foreach (var ue in ueList)
            {
                UserModel uModel = new UserModel
                {
                    Id = ue.Id,
                    FullName = ue.FullName,
                    Discriminator = ue.Discriminator,
                    Document = ue.Document,
                };

                umList.Add(uModel);
            }
            
            return umList;
        }
    }
}
