using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Qualify.Models
{
    public class Claim
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Dirpath { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateStart { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateEnd { get; set; }

        public Client Client { get; set; }
        public ICollection<ClaimHistory> ClaimHistories { get; set; }
        public ICollection<ClaimExpence> ClaimExpences { get; set; }
    }
}
