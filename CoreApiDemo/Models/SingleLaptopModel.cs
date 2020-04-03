using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiDemo.Models
{
    public class SingleLaptopModel
    {
        public int LaptopId { get; set; }
        public string BrandName { get; set; }

        public int? EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int? DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
