using Microsoft.AspNetCore.Mvc;
using SpicyX.Application;
using SpicyX.Application.DataTransfer;
using SpicyX.Implementation.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SpicyX.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public RegistrationController(UseCaseExecutor executor)
        {

            _executor = executor;
        }
        // GET: api/<RegistrationController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<RegistrationController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RegistrationController>
        [HttpPost]
        public IActionResult Post([FromBody] UserDto dto,
            [FromServices] UserInsert command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(201, "Successfully registered!");
        }

        // PUT api/<RegistrationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RegistrationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
