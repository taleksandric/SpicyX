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
    public class ReservationController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public ReservationController(UseCaseExecutor executor)
        {

            _executor = executor;
        }
        // GET: api/<ReservationController>
        [HttpGet]
        [Authorize]
        public IActionResult Get([FromQuery] ReservationSearch search, [FromServices] ReservationQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET api/<ReservationController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ReservationController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] ReservationDto dto,
            [FromServices] ReservationInsert command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(201, "You successfully made a reservation!");
        }

        // PUT api/<ReservationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReservationController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromServices] DeleteReservation command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
