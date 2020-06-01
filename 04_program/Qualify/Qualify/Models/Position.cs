using System;
using System.Collections.Generic;

namespace Qualify.Models
{
    public partial class Position
    {
        public Position()
        {
            Worker = new HashSet<Worker>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double Coef { get; set; }
        public short MedInspPeriod { get; set; }
        public short DepartmentId { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<Worker> Worker { get; set; }
    }
}
