using System;
using System.Collections.Generic;

namespace Qualify.Models
{
    public partial class Warehouse
    {
        public Warehouse()
        {
            Department = new HashSet<Department>();
            WhItems = new HashSet<WhItems>();
        }

        public short Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Department> Department { get; set; }
        public virtual ICollection<WhItems> WhItems { get; set; }
    }
}
