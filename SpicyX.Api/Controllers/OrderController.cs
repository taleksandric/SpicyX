using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpicyX.Application;
using SpicyX.Application.DataTransfer;
using SpicyX.Application.Search;
using SpicyX.Implementation.Commands;
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
    public class OrderController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public OrderController(UseCaseExecutor executor)
        {

            _executor = executor;
        }
        // GET: api/<OrderController>
        [HttpGet]
        [Authorize]
        public IActionResult Get([FromQuery] OrderSearch search,
            [FromServices] OrderQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // POST api/<OrderController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] OrderDto dto, [FromServices] OrderInsert command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(201, "Successfuly added order!");
        }

        

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromServices] DeleteOrder command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
