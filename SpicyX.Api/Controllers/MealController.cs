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
    public class MealController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public MealController(UseCaseExecutor executor)
        {
           
            _executor = executor;
        }
        // GET: api/<MealController>
        [HttpGet]
        public IActionResult Get([FromQuery] MealSearch search, [FromServices] MealQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET api/<MealController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MealController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] MealDto dto, [FromServices] InsertMeal command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(201, "Successfuly added new meal!");
        }

        // PUT api/<MealController>/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] MealDto dto, [FromServices] MealUpdate command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE api/<MealController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromServices] MealDelete command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
