using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Qualify.Models
{
    public class ClaimHistory
    {
        public int ID { get; set; }
        public int ClaimID { get; set; }
        public string Description { get; set; }
        public int EmployeeID { get; set; }
        public bool? Performed { get; set; }
        public bool? Done { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateStart { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateEnd { get; set; }

        public Employee Employee { get; set; }
        public Claim Claim { get; set; }
    }
}
