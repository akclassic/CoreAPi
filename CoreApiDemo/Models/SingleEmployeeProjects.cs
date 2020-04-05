using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiDemo.Models
{
    public class SingleEmployeeProjects
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<EmployeeProjectList> EmployeeProjectList { get; set; }
    }

    public class EmployeeProjectList
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
    }
}
