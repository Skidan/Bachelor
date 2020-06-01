using System;
using System.Collections.Generic;

namespace Qualify.Models
{
    public partial class OrderType
    {
        public OrderType()
        {
            Order = new HashSet<Order>();
        }

        public short Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
