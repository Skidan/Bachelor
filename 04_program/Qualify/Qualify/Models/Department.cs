using System;
using System.Collections.Generic;

namespace Qualify.Models
{
    public partial class Department
    {
        public Department()
        {
            ClaimExpences = new HashSet<ClaimExpences>();
            Position = new HashSet<Position>();
        }

        public short Id { get; set; }
        public string Name { get; set; }
        public string DeptCode { get; set; }
        public int DeptHead { get; set; }
        public short DeptWarehouses { get; set; }
        public short DeptAccounts { get; set; }
        public short CdeptCompetentionPattern { get; set; }

        public virtual CompetentionPattern CdeptCompetentionPatternNavigation { get; set; }
        public virtual Account DeptAccountsNavigation { get; set; }
        public virtual Employee DeptHeadNavigation { get; set; }
        public virtual Warehouse DeptWarehousesNavigation { get; set; }
        public virtual ICollection<ClaimExpences> ClaimExpences { get; set; }
        public virtual ICollection<Position> Position { get; set; }
    }
}
