using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qualify.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int? DepartmentID { get; set; }
        public string? Position { get; set; }

        public ICollection<ClaimHistory> ClaimHistories { get; set; }
        public ICollection<Tool> Tools { get; set; }
        public Department Department { get; set; }
    }
}
