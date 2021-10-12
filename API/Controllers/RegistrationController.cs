using Application;
using Application.Commands.Users;
using Application.DataTransfer.UsersDto;
using Microsoft.AspNetCore.Mvc;
using API.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;
        private readonly HashUsingSha256 _hash;
        public RegistrationController(UseCaseExecutor executor, HashUsingSha256 hash)
        {
            _executor = executor;
            _hash = hash;
        }

        // POST api/<RegistrationController>
        [HttpPost]
        public IActionResult Post([FromBody] UserDto dto,[FromServices] IRegisterUserCommand command)
        {
            dto.Password = _hash.ComputeSha256Hash(dto.Password);
            _executor.ExecuteCommand(command, dto);
            return StatusCode(201);
        }
     
    }
}
