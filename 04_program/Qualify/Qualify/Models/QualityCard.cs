using System;
using System.Collections.Generic;

namespace Qualify.Models
{
    public partial class QualityCard
    {
        public QualityCard()
        {
            Order = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Link { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
