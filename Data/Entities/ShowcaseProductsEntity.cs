using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StuffAndThings.Data.Entities
{
    public class ShowcaseProductsEntity
    {
        public Guid Id { get; set; }
        [ForeignKey("ProductId")]
        public virtual ProductEntity Product { get; set; }
        [ForeignKey("ShowCaseId")]
        public virtual ShowcaseEntity ShowCase { get; set; }
        public Guid ProductId { get; set; }
        public Guid ShowCaseId { get; set; }
    }
}
