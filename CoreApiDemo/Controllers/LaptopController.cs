using CoreApiDemo.BAL.Shared;
using CoreApiDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaptopController : ControllerBase
    {
        private readonly ILaptopManager _laptopManger;

        public LaptopController(ILaptopManager laptopManager)
        {
            _laptopManger = laptopManager;
        }

        // GET: api/Laptop
        [HttpGet]
        public async Task<IEnumerable<LaptopListModel>> Get()
        {
            return await _laptopManger.GetLaptopList();
        }

        // GET: api/Laptop/5
        [HttpGet("{id}")]
        public async Task<SingleLaptopModel> Get(int id)
        {
            return await _laptopManger.GetSingleLaptopDetail(id);
        }

        // POST: api/Laptop
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Laptop/5
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
