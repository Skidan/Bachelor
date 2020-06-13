using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qualify.Models
{
    public class ToolType
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CheckIntervalWeeks { get; set; }

        public ICollection<Tool> Tools { get; set; }
    }
}
