using CoreApiDemo.BAL.Shared;
using CoreApiDemo.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiDemo.BAL.Implementation
{
    public class ProjectManager : IProjectManager
    {
        public async Task<IEnumerable<ProjectsListModel>> GetProjectsList()
        {
            using (var context = new CompanyDbContext())
            {
                var projects = await context.Project
                                .Include(p => p.EmployeeProject)
                                .Select(p => new ProjectsListModel() { 
                                    Id = p.Id,
                                    Name = p.ProjectName,
                                    Duration = p.Duration
                                })
                                .ToListAsync();

                return projects;
            }
        }

        public async Task<SingleProjectModel> GetSingleProjectDetails(int id)
        {
            using (var context = new CompanyDbContext())
            {
                var project = context.Project
                                .Where(p => p.Id == id)
                                .Include(p => p.EmployeeProject)
                                .Select(p => new SingleProjectModel()
                                {
                                    Id = p.Id,
                                    Name = p.ProjectName,
                                    Duration = p.Duration,
                                    EmployeesList = context.EmployeeProject.Where(ep => ep.ProjectId == p.Id).Select(ep => new EmployeeListForProject() { 
                                        EmployeeId = ep.EmployeeId,
                                        EmployeeName = $"{ep.Employee.FirstName} {ep.Employee.LastName}"
                                    }).ToList()
                                }).ToList();

                return project[0];
            }
        }
    }
}
