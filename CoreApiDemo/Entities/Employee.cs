using System;
using System.Collections.Generic;

namespace CoreApiDemo.Models
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeProject = new HashSet<EmployeeProject>();
            Laptop = new HashSet<Laptop>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int? DepartmentId { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<EmployeeProject> EmployeeProject { get; set; }
        public virtual ICollection<Laptop> Laptop { get; set; }
    }
}
