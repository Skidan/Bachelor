using System;
using System.Collections.Generic;

namespace Qualify.Models
{
    public partial class ClaimExpences
    {
        public int Id { get; set; }
        public int ClaimId { get; set; }
        public DateTime Date { get; set; }
        public double Sum { get; set; }
        public string Link { get; set; }
        public string Comment { get; set; }
        public short DepartmentId { get; set; }

        public virtual Claim Claim { get; set; }
        public virtual Department Department { get; set; }
    }
}
