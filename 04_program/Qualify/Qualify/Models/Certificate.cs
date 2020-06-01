using System;
using System.Collections.Generic;

namespace Qualify.Models
{
    public partial class Certificate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CertId { get; set; }
        public string Link { get; set; }
        public int EmployeeId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTill { get; set; }
        public short ReminderMonth { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
