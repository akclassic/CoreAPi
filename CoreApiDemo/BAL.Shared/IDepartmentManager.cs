using CoreApiDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiDemo.BAL.Shared
{
    public interface IDepartmentManager
    {
        Task<IEnumerable<DepartmentListModel>> GetDepartmentList();

        Task<SingleDepartmentModel> GetSingleDepartmentDetail(int id);
    }
}
