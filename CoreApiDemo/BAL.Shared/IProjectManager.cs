using CoreApiDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiDemo.BAL.Shared
{
    public interface IProjectManager
    {
        public Task<IEnumerable<ProjectsListModel>> GetProjectsList();
        public Task<SingleProjectModel> GetSingleProjectDetails(int id);
    }
}
