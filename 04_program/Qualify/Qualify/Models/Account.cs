using System;
using System.Collections.Generic;

namespace Qualify.Models
{
    public partial class Account
    {
        public Account()
        {
            Department = new HashSet<Department>();
        }

        public short Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Department> Department { get; set; }
    }
}
