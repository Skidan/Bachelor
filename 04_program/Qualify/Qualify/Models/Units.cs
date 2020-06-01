using System;
using System.Collections.Generic;

namespace Qualify.Models
{
    public partial class Units
    {
        public Units()
        {
            WhItems = new HashSet<WhItems>();
        }

        public short Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<WhItems> WhItems { get; set; }
    }
}
