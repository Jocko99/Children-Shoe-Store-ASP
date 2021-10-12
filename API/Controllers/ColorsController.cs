using Application;
using Application.Commands.Colors;
using Application.DataTransfer;
using Application.Queries;
using Application.Searches;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public ColorsController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/<ColorsController>
        [HttpGet]
        public IActionResult Get([FromQuery] ColorSearch search, [FromServices] IGetColorQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }


        // POST api/<ColorsController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] ColorDto dto, [FromServices] ICreateColorCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<ColorsController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ColorDto dto,[FromServices] IUpdateColorCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE api/<ColorsController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteColorCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
