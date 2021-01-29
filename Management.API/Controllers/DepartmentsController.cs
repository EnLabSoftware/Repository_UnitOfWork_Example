using Management.API.Services;
using Management.Domain.Departments;
using Management.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Management.API.Controllers
{
    [ApiController]
    [Route("departments")]
    public class DepartmentsController : ControllerBase
    {
        private readonly DepartmentService _service;
        public DepartmentsController(DepartmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            await _service.AddAllEntitiesAsync();

            return Ok();
        }
    }
}
