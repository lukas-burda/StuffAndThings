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
        public string CPF { get; set; }
        public string CNPJ { get; set; }
        public string Discriminator { get; set; }
        public string Gender { get; set; }
    }
}
