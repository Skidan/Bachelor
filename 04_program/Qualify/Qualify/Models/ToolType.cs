using System;
using System.Collections.Generic;

namespace Qualify.Models
{
    public partial class ToolType
    {
        public ToolType()
        {
            ToolList = new HashSet<ToolList>();
            ToolProp = new HashSet<ToolProp>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public short CheckPeriodMonth { get; set; }

        public virtual ICollection<ToolList> ToolList { get; set; }
        public virtual ICollection<ToolProp> ToolProp { get; set; }
    }
}
