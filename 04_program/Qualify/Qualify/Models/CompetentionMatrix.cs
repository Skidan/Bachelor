using System;
using System.Collections.Generic;

namespace Qualify.Models
{
    public partial class CompetentionMatrix
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public short? Languages { get; set; }
        public short? Welding { get; set; }
        public short? Brakes { get; set; }
        public short? Forklift { get; set; }
        public short? Drawing { get; set; }
        public short? Constructing { get; set; }
        public short? Chemistry { get; set; }
        public short? Accounting { get; set; }
        public short? Management { get; set; }
        public short? Quality { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
