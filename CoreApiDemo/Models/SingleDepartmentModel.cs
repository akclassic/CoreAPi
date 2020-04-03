using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiDemo.Models
{
    public class SingleDepartmentModel
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        //public int EmployeeId { get; set; }
        //public string EmployeeName { get; set; }
        //public int LaptopId { get; set; }
        //public string BrandName { get; set; }
        public List<EmployeeForDepartment> Employees { get; set; }
    }

    public class EmployeeForDepartment
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public LaptopForDepartment LaptopForDepartment { get; set; }
    }

    public class LaptopForDepartment
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
    }
}
