using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiDemo.Models
{
    public class SingleEmployeeModel
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public int? DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int LaptopId { get; set; }
        public string LaptopBrand { get; set; }
    }
}
