using System;
using System.Collections.Generic;

namespace Qualify.Models
{
    public partial class Order
    {
        public Order()
        {
            Claim = new HashSet<Claim>();
        }

        public int Id { get; set; }
        public string IntCode { get; set; }
        public string ExtCode { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ProdDate { get; set; }
        public decimal Price { get; set; }
        public string Comment { get; set; }
        public int ClientId { get; set; }
        public short OrderTypeId { get; set; }
        public int ProductId { get; set; }
        public int QualityCardId { get; set; }

        public virtual Client Client { get; set; }
        public virtual OrderType OrderType { get; set; }
        public virtual Product Product { get; set; }
        public virtual QualityCard QualityCard { get; set; }
        public virtual ICollection<Claim> Claim { get; set; }
    }
}
