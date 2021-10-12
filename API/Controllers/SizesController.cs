using Application;
using Application.Commands.Sizes;
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
    public class SizesController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public SizesController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/<SizesController>
        [HttpGet]
        public IActionResult Get([FromQuery] SizeSearch search, [FromServices] IGetSizeQuery query)
        {
            return Ok(_executor.ExecuteQuery(query,search));
        }


        // POST api/<SizesController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] SizeDto dto, [FromServices] ICreateSizeCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<SizesController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SizeDto dto, [FromServices] IUpdateSizeCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE api/<SizesController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteSizeCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
