using Application;
using Application.Commands.Seasons;
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
    public class SeasonController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public SeasonController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/<SeasonController>
        [HttpGet]
        public IActionResult Get([FromQuery] SeasonSearch search, [FromServices] IGetSeasonQuery query)
        {
            return Ok(_executor.ExecuteQuery(query,search));
        }


        // POST api/<SeasonController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] SeasonDto dto,[FromServices] ICreateSeasonCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<SeasonController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SeasonDto dto, [FromServices] IUpdateSeasonCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE api/<SeasonController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteSeasonCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
