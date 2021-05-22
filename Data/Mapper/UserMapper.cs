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
                CNPJ = uModel.CNPJ,
                CPF = uModel.CPF,
                Discriminator = uModel.Discriminator,
                FullName = uModel.FullName,
                Gender = uModel.Gender,
                Id = uModel.Id
            };
            return uEntity;
        }

        public static UserModel Mapper(UserEntity uEntity)
        {
            UserModel uModel = new UserModel
            {
                Id = uEntity.Id,
                Gender = uEntity.Gender,
                FullName = uEntity.FullName,
                Discriminator = uEntity.Discriminator,
                CPF = uEntity.CPF,
                CNPJ = uEntity.CNPJ
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
                    CNPJ = um.CNPJ,
                    CPF = um.CPF,
                    Discriminator = um.Discriminator,
                    FullName = um.FullName,
                    Gender = um.Gender,
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
                    Gender = ue.Gender,
                    FullName = ue.FullName,
                    Discriminator = ue.Discriminator,
                    CPF = ue.CPF,
                    CNPJ = ue.CNPJ
                };

                umList.Add(uModel);
            }
            
            return umList;
        }
    }
}
