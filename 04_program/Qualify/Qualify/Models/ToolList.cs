using System;
using System.Collections.Generic;

namespace Qualify.Models
{
    public partial class ToolList
    {
        public int Id { get; set; }
        public DateTime LastCheckDate { get; set; }
        public int ToolTypeId { get; set; }
        public int ToolPropId { get; set; }
        public int WorkerId { get; set; }
        public short? ToolUtilized { get; set; }

        public virtual ToolProp ToolProp { get; set; }
        public virtual ToolType ToolType { get; set; }
        public virtual Worker Worker { get; set; }
    }
}
