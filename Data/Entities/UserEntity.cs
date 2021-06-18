using StuffAndThings.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffAndThings.Data.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Document { get; set; }
        public DiscriminatorEnum Discriminator { get; set; }
    }
}
