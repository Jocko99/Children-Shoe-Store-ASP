using Application;
using Application.Commands.Groups;
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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public GroupsController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/<GroupsController>
        [HttpGet]
        public IActionResult Get([FromQuery] GroupSearch search, [FromServices] IGetGroupQuery query)
        {
            return Ok(_executor.ExecuteQuery(query,search));
        }


        // POST api/<GroupsController>
        [HttpPost]
        public IActionResult Post([FromBody] GroupDto dto, [FromServices] ICreateGroupCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<GroupsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] GroupDto dto, [FromServices] IUpdateGroupCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE api/<GroupsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteGroupCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
