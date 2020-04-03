using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApiDemo.BAL.Shared;
using CoreApiDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentManager _departmentManger;

        public DepartmentController(IDepartmentManager departmentManager)
        {
            _departmentManger = departmentManager;
        }
        // GET: api/Department
        [HttpGet]
        public async Task<IEnumerable<DepartmentListModel>> Get()
        {
            return await _departmentManger.GetDepartmentList();
        }

        // GET: api/Department/5
        [HttpGet("{id}")]
        public async Task<SingleDepartmentModel> Get(int id)
        {
            return await _departmentManger.GetSingleDepartmentDetail(id);
        }

        //// POST: api/Department
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Department/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
