﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qualify.Models
{
    public class ClaimExpenceModel
    {
        public int ID { get; set; }
        public double Costs { get; set; }
        public string Description { get; set; }
        public int DepartmentID { get; set; }
        public int ClaimID { get; set; }
    }
}
