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
    }
}
