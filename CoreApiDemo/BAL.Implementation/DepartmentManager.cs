using CoreApiDemo.BAL.Shared;
using CoreApiDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiDemo.BAL.Implementation
{
    public class DepartmentManager : IDepartmentManager
    {
        public async Task<IEnumerable<DepartmentListModel>> GetDepartmentList()
        {
            using (var context = new CompanyDbContext())
            {
                var department = await context.Department
                                        .Include(d => d.Employee)
                                        .Select(d => new DepartmentListModel()
                                        {
                                            Id = d.Id,
                                            DepartmentName = d.DepartmentName
                                        })
                                        .ToListAsync();

                return department;
            }
        }

        public async Task<SingleDepartmentModel> GetSingleDepartmentDetail(int id)
        {
            using (var context = new CompanyDbContext())
            {
                var department = await context.Department
                                 .Where(d => d.Id == id)
                                 .Include(d => d.Employee)
                                 .Select(d => new SingleDepartmentModel()
                                 {
                                     DepartmentId = d.Id,
                                     DepartmentName = d.DepartmentName,
                                     //EmployeeId = d.Employee.FirstOrDefault(e => e.DepartmentId == d.Id).Id,
                                     //EmployeeName = $"{d.Employee.FirstOrDefault(e => e.DepartmentId == d.Id).FirstName} {d.Employee.FirstOrDefault(e => e.DepartmentId == d.Id).FirstName}",
                                     //LaptopId = d.Employee.FirstOrDefault(e => e.DepartmentId == d.Id).Laptop.FirstOrDefault(l => l.EmployeeId == d.Employee.FirstOrDefault(e => e.DepartmentId == d.Id).Id).Id,
                                     //BrandName = d.Employee.FirstOrDefault(e => e.DepartmentId == d.Id).Laptop.FirstOrDefault(l => l.EmployeeId == d.Employee.FirstOrDefault(e => e.DepartmentId == d.Id).Id).BrandName,
                                     Employees = d.Employee.Where(e => e.DepartmentId == d.Id).Select(e => new EmployeeForDepartment()
                                     {
                                         Id = e.Id,
                                         FirstName = e.FirstName,
                                         LastName = e.LastName,
                                         LaptopForDepartment = e.Laptop.Where(l => l.EmployeeId == e.Id).Select(l => new LaptopForDepartment()
                                         {
                                             Id = l.Id,
                                             BrandName = l.BrandName
                                         }).FirstOrDefault()
                                     }).ToList()

                                 }).ToListAsync();

                return department[0];
            }
        }
    }
}
