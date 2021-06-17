using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpicyX.Application;
using SpicyX.Application.DataTransfer;
using SpicyX.Application.Exceptions;
using SpicyX.Application.Interfaces;
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
    public class UserController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;
        private readonly IApplicationUser _actor;

        public UserController(UseCaseExecutor executor, IApplicationUser actor)
        {

            _executor = executor;
            _actor = actor;
        }
        // GET: api/<UserController>
        [HttpGet]
        [Authorize]
        public IActionResult Get([FromQuery] UserSearch search, [FromServices] UserQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }
        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] UserDto dto,
            [FromServices] UserUpdate command)
        {
            dto.Id = id;
            if(_actor.Id != id)
            {
                throw new UnauthorizedUseCaseException(command, _actor);
            }
            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromServices] UserDelete command)
        {
            if (_actor.Id != id)
            {
                throw new UnauthorizedUseCaseException(command, _actor);
            }
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
