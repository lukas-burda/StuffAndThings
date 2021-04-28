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
            UserEntity uEntity = new UserEntity();
            uEntity.CNPJ = uModel.CNPJ;
            uEntity.CPF = uModel.CPF;
            uEntity.Discriminator = uModel.Discriminator;
            uEntity.FullName = uModel.FullName;
            uEntity.Gender = uModel.Gender;
            uEntity.Id = uModel.Id;
            return uEntity;
        }

        public static UserModel Mapper(UserEntity uEntity)
        {
            UserModel uModel = new UserModel();
            uModel.Id = uEntity.Id;
            uModel.Gender = uEntity.Gender;
            uModel.FullName = uEntity.FullName;
            uModel.Discriminator = uEntity.Discriminator;
            uModel.CPF = uEntity.CPF;
            uModel.CNPJ = uEntity.CNPJ;
            return uModel;
        }
    }
}
