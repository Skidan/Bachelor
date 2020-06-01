using System;
using System.Collections.Generic;

namespace Qualify.Models
{
    public partial class WhItems
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descr { get; set; }
        public short UnitsId { get; set; }
        public float Quantity { get; set; }
        public decimal Price { get; set; }
        public short WarehouseId { get; set; }

        public virtual Units Units { get; set; }
        public virtual Warehouse Warehouse { get; set; }
    }
}
