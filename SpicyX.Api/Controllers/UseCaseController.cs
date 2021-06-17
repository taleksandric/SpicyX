using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpicyX.Application;
using SpicyX.Application.Search;
using SpicyX.Implementation.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SpicyX.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UseCaseController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public UseCaseController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/<UseCaseLogsController>
        [HttpGet]
        [Authorize]
        public IActionResult Get([FromQuery] UseCaseSearch search,
            [FromServices] UseCaseQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }


    }
}
