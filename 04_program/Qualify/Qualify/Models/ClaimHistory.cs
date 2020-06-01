using System;
using System.Collections.Generic;

namespace Qualify.Models
{
    public partial class ClaimHistory
    {
        public int Id { get; set; }
        public int ClaimId { get; set; }
        public int ActionId { get; set; }

        public virtual Action Action { get; set; }
        public virtual Claim Claim { get; set; }
    }
}
