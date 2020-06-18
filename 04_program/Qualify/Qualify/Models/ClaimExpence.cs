using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qualify.Models
{
    public class ClaimExpence
    {
        public int ID { get; set; }
        public double Costs { get; set; }
        public string Description { get; set; }
        public int DepartmentID { get; set; }
        public int ClaimID { get; set; }

        public Claim Claim { get; set; }
        public Department Department { get; set; }
    }
}
