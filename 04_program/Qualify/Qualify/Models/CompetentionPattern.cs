using System;
using System.Collections.Generic;

namespace Qualify.Models
{
    public partial class CompetentionPattern
    {
        public CompetentionPattern()
        {
            Department = new HashSet<Department>();
        }

        public short Id { get; set; }
        public string Name { get; set; }
        public short? Languages { get; set; }
        public short? Welding { get; set; }
        public short? Brakes { get; set; }
        public short? Forklift { get; set; }
        public short? Drawings { get; set; }
        public short? Constructing { get; set; }
        public short? Chemistry { get; set; }
        public short? Accounting { get; set; }
        public short? Management { get; set; }
        public short? Quality { get; set; }

        public virtual ICollection<Department> Department { get; set; }
    }
}
