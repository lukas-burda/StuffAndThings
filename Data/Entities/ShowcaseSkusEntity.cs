using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StuffAndThings.Data.Entities
{
    public class ShowcaseSkusEntity
    {
        public Guid Id { get; set; }
        [ForeignKey("SkuId")]
        public virtual SkuEntity Sku { get; set; }
        [ForeignKey("ShowCaseId")]
        public virtual ShowcaseEntity ShowCase { get; set; }
        public Guid SkuId { get; set; }
        public Guid ShowCaseId { get; set; }
    }
}
