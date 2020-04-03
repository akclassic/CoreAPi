using CoreApiDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiDemo.BAL.Shared
{
    public interface ILaptopManager
    {
        public Task<IEnumerable<LaptopListModel>> GetLaptopList();

        public Task<SingleLaptopModel> GetSingleLaptopDetail(int id);
    }
}
