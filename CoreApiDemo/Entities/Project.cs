using System;
using System.Collections.Generic;

namespace CoreApiDemo.Models
{
    public partial class Project
    {
        public Project()
        {
            EmployeeProject = new HashSet<EmployeeProject>();
        }

        public int Id { get; set; }
        public string ProjectName { get; set; }
        public int Duration { get; set; }

        public virtual ICollection<EmployeeProject> EmployeeProject { get; set; }
    }
}
