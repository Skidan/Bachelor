using System;
using System.Collections.Generic;

namespace Qualify.Models
{
    public partial class Action
    {
        public Action()
        {
            ClaimComments = new HashSet<ClaimComments>();
            ClaimHistory = new HashSet<ClaimHistory>();
        }

        public int Id { get; set; }
        public string Aim { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public int WorkerId { get; set; }

        public virtual Worker Worker { get; set; }
        public virtual ICollection<ClaimComments> ClaimComments { get; set; }
        public virtual ICollection<ClaimHistory> ClaimHistory { get; set; }
    }
}
