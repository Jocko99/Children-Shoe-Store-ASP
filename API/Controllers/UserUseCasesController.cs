using Application;
using Application.Commands.Users;
using Application.DataTransfer.UsersDto;
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
    public class UserUseCasesController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public UserUseCasesController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/<UserUseCasesController>
        [HttpGet]
        public IActionResult Get([FromQuery] UseCaseSearch search, [FromServices] IGetUseCaseQuery query)
        {
            return Ok(_executor.ExecuteQuery(query,search));
        }


        // POST api/<UserUseCasesController>
        [HttpPost]
        public IActionResult Post([FromBody] UserUseCaseDto dto , [FromServices] ICreateUserUseCaseCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<UserUseCasesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserUseCaseDto dto, [FromServices] IUpdateUserUseCaseCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE api/<UserUseCasesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteUserUseCaseCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
