using System;
using System.Collections.Generic;

namespace Qualify.Models
{
    public partial class ToolProp
    {
        public ToolProp()
        {
            ToolList = new HashSet<ToolList>();
        }

        public int Id { get; set; }
        public int ToolTypeId { get; set; }
        public string Prop { get; set; }

        public virtual ToolType ToolType { get; set; }
        public virtual ICollection<ToolList> ToolList { get; set; }
    }
}
