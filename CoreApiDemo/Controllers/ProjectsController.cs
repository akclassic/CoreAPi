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
    public class ProjectsController : ControllerBase
    {
        IProjectManager _projectManager;

        public ProjectsController(IProjectManager projectManager)
        {
            _projectManager = projectManager;
        }
        [HttpGet]
        public async Task<IEnumerable<ProjectsListModel>> Get()
        {
            return await _projectManager.GetProjectsList();
        }

        [HttpGet("{id}")]
        public async Task<SingleProjectModel> Get(int id)
        {
            return await _projectManager.GetSingleProjectDetails(id);
        }
    }
}