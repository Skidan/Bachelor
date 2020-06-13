using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qualify.Models
{
    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string? Account { get; set; }
        public string? Warehouse { get; set; }

        public ICollection<Employee> Employees { get; set; }
        public ICollection<ClaimExpence> ClaimExpences { get; set; }
    }
}
