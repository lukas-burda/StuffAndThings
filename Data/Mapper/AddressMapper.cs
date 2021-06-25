using StuffAndThings.Data.Entities;
using StuffAndThings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffAndThings.Data.Mapper
{
    public class AddressMapper
    {
        public static AddressModel Mapper(AddressEntity addressEntity)
        {
            if (addressEntity != null)
            {
                AddressModel addressModel = new AddressModel
                {
                    Id = addressEntity.Id,
                    CEP = addressEntity.CEP,
                    Country = addressEntity.Country,
                    Number = addressEntity.Number,
                    State = addressEntity.State,
                    Street = addressEntity.Street
                };
                return addressModel;
            }
            return null;
        }

        public static AddressEntity Mapper(AddressModel addressModel)
        {
            if (addressModel != null)
            {
                AddressEntity addressEntity = new AddressEntity
                {
                    Id = addressModel.Id,
                    CEP = addressModel.CEP,
                    Country = addressModel.Country,
                    Number = addressModel.Number,
                    State = addressModel.State,
                    Street = addressModel.Street
                };
                return addressEntity;
            }
            return null;
        }

        public static List<AddressModel> Mapper(List<AddressEntity> addressEntity)
        {
            if (addressEntity != null)
            {
                List<AddressModel> addressesModel = new List<AddressModel>();
                foreach (var item in addressEntity)
                {
                    AddressModel addressModel = new AddressModel
                    {
                        Id = item.Id,
                        CEP = item.CEP,
                        Country = item.Country,
                        Number = item.Number,
                        State = item.State,
                        Street = item.Street
                    };
                    addressesModel.Add(addressModel);
                }
                return addressesModel;
            }
            return null;
        }

        public static List<AddressEntity> Mapper(List<AddressModel> addressModel)
        {
            if (addressModel != null)
            {
                List<AddressEntity> addressesEntity = new List<AddressEntity>();
                foreach (var item in addressModel)
                {
                    AddressEntity addressEntity = new AddressEntity
                    {
                        Id = item.Id,
                        CEP = item.CEP,
                        Country = item.Country,
                        Number = item.Number,
                        State = item.State,
                        Street = item.Street
                    };
                    addressesEntity.Add(addressEntity);
                }
                return addressesEntity;
            }
            return null;
        }
    }
}
