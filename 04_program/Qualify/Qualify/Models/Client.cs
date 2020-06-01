using System;
using System.Collections.Generic;

namespace Qualify.Models
{
    public partial class Client
    {
        public Client()
        {
            Claim = new HashSet<Claim>();
            Order = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public short CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Claim> Claim { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
