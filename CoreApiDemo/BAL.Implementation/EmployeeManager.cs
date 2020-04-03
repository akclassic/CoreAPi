using CoreApiDemo.BAL.Shared;
using CoreApiDemo.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiDemo.BAL.Implementation
{
    public class EmployeeManager : IEmployeeManager
    {
        public async Task<IEnumerable<EmployeeListModel>> GetEmployeeList()
        {
            using (var context = new CompanyDbContext())
            {
                var employees = await context.Employee
                                .Include(e => e.Department)
                                .Include(e => e.Laptop)
                                .Include(e => e.EmployeeProject)
                                .Select(e => new EmployeeListModel()
                                {
                                    Id = e.Id,
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                    Email = e.LastName,
                                    DepartmentId = e.DepartmentId,
                                    ProjectCount = e.EmployeeProject.Count
                                })
                                .ToListAsync();
                return employees;
            }
        }

        public async Task<SingleEmployeeModel> GetSingleEmployeeDetail(int id)
        {
            using (var context = new CompanyDbContext())
            {
                var employee = await context.Employee
                                .Where(e => e.Id == id)
                                .Include(e => e.Department)
                                .Include(e => e.Laptop)
                                .Select(e => new SingleEmployeeModel()
                                {
                                    EmployeeId = e.Id,
                                    Name = e.FirstName + " " + e.LastName,
                                    Email = e.Email,
                                    DepartmentId = e.DepartmentId,
                                    DepartmentName = e.Department.DepartmentName,
                                    LaptopId = e.Laptop.FirstOrDefault(l => l.EmployeeId == e.Id).Id,
                                    LaptopBrand = e.Laptop.FirstOrDefault(l => l.EmployeeId == e.Id).BrandName
                                }).ToListAsync();

                return employee[0];
            }
        }
    }
}
