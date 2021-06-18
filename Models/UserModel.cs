using Microsoft.AspNetCore.Identity;
using StuffAndThings.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffAndThings.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Document { get; set; }
        public DiscriminatorEnum Discriminator { get; set; }
    }
}
