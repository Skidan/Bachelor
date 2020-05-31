using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Qualify.Domain.Entities
{
    public abstract class EntityBase
    {
        [Required]
        public Guid ID { get; set; }

        [Display(Name = "Name (heading)")]
        public virtual string Title { get; set; }

        [Display(Name = "Name (heading)")]
        public virtual string Title { get; set; }

        [Display(Name = "Name (heading)")]
        public virtual string Title { get; set; }

        [Display(Name = "Name (heading)")]
        public virtual string Title { get; set; }

        [Display(Name = "Name (heading)")]
        public virtual string Title { get; set; }
    }
}
