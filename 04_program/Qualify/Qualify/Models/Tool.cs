using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qualify.Models
{
    public class Tool
    {
        public int ID { get; set; }
        public int ToolTypeID { get; set; }
        public int EmployeeID { get; set; }

        public Employee Employee { get; set; }
        public ToolType ToolType { get; set; }
    }
}
