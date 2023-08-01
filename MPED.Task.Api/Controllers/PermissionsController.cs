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
    public class PermissionsController : ControllerBase
    {
        private readonly ILogger<PermissionsController> _logger;

        public PermissionsController(ILogger<PermissionsController> logger)
        {
            _logger = logger;
        }

        //[HttpPost("create")]
        //public void CreatePermission(int role) { }
        //[HttpGet("get")]
        //public void GetPermissionById(int id) { }
        //[HttpGet("getAll")]
        //public void GetAllPermissions() { }
        //[HttpPatch("update")]
        //public void UpdatePermission(int id, int role) { }
        //[HttpDelete("delete")]
        //public void DeletePermissionById(int id) { }
    }
}
