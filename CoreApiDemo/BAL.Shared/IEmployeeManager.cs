using CoreApiDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiDemo.BAL.Shared
{
    public interface IEmployeeManager
    {
        public Task<IEnumerable<EmployeeListModel>> GetEmployeeList();

        public Task<SingleEmployeeModel> GetSingleEmployeeDetail(int id);
    }
}
