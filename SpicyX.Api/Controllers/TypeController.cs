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
    public class TypeController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public TypeController(UseCaseExecutor executor)
        {

            _executor = executor;
        }
        // GET: api/<TypeController>
        [HttpGet]
        public IActionResult Get([FromQuery] TypeSearch search, [FromServices] TypeQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

       

        // POST api/<TypeController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] TypeDto dto, [FromServices] InsertType command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(201, "Successfuly added a new meal!");
        }

        // PUT api/<TypeController>/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] TypeDto dto, [FromServices] TypeUpdate command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE api/<TypeController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromServices] DeleteType command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
