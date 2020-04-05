using System.Collections.Generic;

namespace CoreApiDemo.Models
{
    public class SingleProjectModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public IEnumerable<EmployeeListForProject> EmployeesList { get; set; }
    }

    public class EmployeeListForProject
    {
        public int? EmployeeId { get; set; }
        public string EmployeeName { get; set; }
    }
}
