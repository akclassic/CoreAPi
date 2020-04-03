using CoreApiDemo.BAL.Shared;
using CoreApiDemo.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiDemo.BAL.Implementation
{
    public class LaptopManager : ILaptopManager
    {
        public async Task<IEnumerable<LaptopListModel>> GetLaptopList()
        {
            using (var context = new CompanyDbContext())
            {
                var laptops = await context.Laptop
                                        .Include(l => l.Employee)
                                        .Select(d => new LaptopListModel()
                                        {
                                            Id = d.Id,
                                            BrandName = d.BrandName,
                                            EmployeeName = context.Employee.FirstOrDefault(e => e.Id == d.EmployeeId).FirstName + " " + context.Employee.FirstOrDefault(e => e.Id == d.EmployeeId).LastName
                                        })
                                        .ToListAsync();

                return laptops;
            }
        }

        public async Task<SingleLaptopModel> GetSingleLaptopDetail(int id)
        {
            using (var context = new CompanyDbContext())
            {
                var laptop = context.Laptop
                                .Where(l => l.Id == id)
                                .Select(l => new SingleLaptopModel()
                                {
                                    LaptopId = l.Id,
                                    BrandName = l.BrandName,
                                    EmployeeId = l.EmployeeId,
                                    EmployeeName = l.Employee.FirstName + " " + l.Employee.LastName,
                                    DepartmentId = l.Employee.DepartmentId,
                                    DepartmentName = l.Employee.Department.DepartmentName
                                }).FirstOrDefault();

                return laptop;
            }
        }
    }
}
