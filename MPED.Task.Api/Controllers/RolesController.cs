using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MPED.Task.Api.Controllers
{
    [ApiController]
    //[Route("[api/v1/roles]")]
    public class RolesController : ControllerBase
    {
        private readonly ILogger<RolesController> _logger;

        public RolesController(ILogger<RolesController> logger)
        {
            _logger = logger;
        }

    //    [HttpPost("create")]
    //    public void CreateRole(int role) { }
    //    [HttpGet("get")]
    //    public void GetRolerById(int id) { }
    //    [HttpGet("getAll")]
    //    public void GetAllRoles() { }
    //    [HttpPatch("update")]
    //    public void UpdateRole(int id, int role) { }
    //    [HttpDelete("delete")]
    //    public void DeleteRoleById(int id) { }
    
    }
}
