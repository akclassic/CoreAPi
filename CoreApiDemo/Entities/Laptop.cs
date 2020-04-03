using System;
using System.Collections.Generic;

namespace CoreApiDemo.Models
{
    public partial class Laptop
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public int? EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
