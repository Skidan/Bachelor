using System;
using System.Collections.Generic;

namespace Qualify.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Certificate = new HashSet<Certificate>();
            CompetentionMatrix = new HashSet<CompetentionMatrix>();
            Department = new HashSet<Department>();
            Worker = new HashSet<Worker>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PersonalIdnum { get; set; }
        public DateTime MedInspectionDate { get; set; }
        public DateTime? Worksfrom { get; set; }
        public DateTime? Workedtill { get; set; }
        public string PhonePrivate { get; set; }
        public string PhoneWork { get; set; }
        public string EmailPrivate { get; set; }
        public string EmailWork { get; set; }
        public string HomeAddress { get; set; }

        public virtual ICollection<Certificate> Certificate { get; set; }
        public virtual ICollection<CompetentionMatrix> CompetentionMatrix { get; set; }
        public virtual ICollection<Department> Department { get; set; }
        public virtual ICollection<Worker> Worker { get; set; }
    }
}
