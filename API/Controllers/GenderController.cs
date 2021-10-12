using Application;
using Application.Commands.Genders;
using Application.DataTransfer;
using Application.Queries;
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
    public class GenderController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public GenderController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/<GenderController>
        [HttpGet]
        public IActionResult Get([FromServices] IGetGendersQuery query)
        {
            return Ok(_executor.ExecuteQuery(query));
        }


        // POST api/<GenderController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] GenderDto dto,[FromServices] ICreateGenderCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<GenderController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] GenderDto dto, [FromServices] IUpdateGenderCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE api/<GenderController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,[FromServices] IDeleteGenderCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
