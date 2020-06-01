using System;
using System.Collections.Generic;

namespace Qualify.Models
{
    public partial class ClaimComments
    {
        public int Id { get; set; }
        public int ActionId { get; set; }
        public DateTime Timestamp { get; set; }
        public string Comment { get; set; }

        public virtual Action Action { get; set; }
    }
}
