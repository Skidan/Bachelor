using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qualify.Models
{
    public class ClaimHistoryModel
    {
        public int ID { get; set; }
        public int ClaimID { get; set; }
        public int ActionID { get; set; }


        public Claim Claim { get; set; }
        public Action Action { get; set; }
    }
}
