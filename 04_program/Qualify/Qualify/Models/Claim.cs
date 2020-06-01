using System;
using System.Collections.Generic;

namespace Qualify.Models
{
    public partial class Claim
    {
        public Claim()
        {
            ClaimExpences = new HashSet<ClaimExpences>();
            ClaimHistory = new HashSet<ClaimHistory>();
        }

        public int Id { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public int OrderId { get; set; }
        public int ClientId { get; set; }

        public virtual Client Client { get; set; }
        public virtual Order Order { get; set; }
        public virtual ICollection<ClaimExpences> ClaimExpences { get; set; }
        public virtual ICollection<ClaimHistory> ClaimHistory { get; set; }
    }
}
