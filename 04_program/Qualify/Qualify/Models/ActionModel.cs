using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qualify.Models
{
    public class ActionModel
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public int EmployeeID { get; set; }
        public bool? Performed { get; set; }
        public bool? Done { get; set; }

        public Employee Employee { get; set; }
        public ICollection<ClaimHistory> ClaimHistories { get; set; }
    }
}
