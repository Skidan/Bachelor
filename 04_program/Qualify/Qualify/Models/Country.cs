using System;
using System.Collections.Generic;

namespace Qualify.Models
{
    public partial class Country
    {
        public Country()
        {
            Client = new HashSet<Client>();
        }

        public short Id { get; set; }
        public string Name { get; set; }
        public string Locale { get; set; }
        public string Tradezone { get; set; }
        public string Currency { get; set; }

        public virtual ICollection<Client> Client { get; set; }
    }
}
