using System;
using System.Collections.Generic;

namespace Qualify.Models
{
    public partial class Worker
    {
        public Worker()
        {
            Action = new HashSet<Action>();
            ToolList = new HashSet<ToolList>();
        }

        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int PositionId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Position Position { get; set; }
        public virtual ICollection<Action> Action { get; set; }
        public virtual ICollection<ToolList> ToolList { get; set; }
    }
}
