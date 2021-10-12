using API.Core;
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
    public class UsersController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;
        private readonly HashUsingSha256 _hash;
        public UsersController(UseCaseExecutor executor, HashUsingSha256 hash )
        {
            _executor = executor;
            _hash = hash;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IActionResult Get([FromQuery] UserSearch search, [FromServices] IGetUsersQuery query)
        {
            return Ok(_executor.ExecuteQuery(query,search));
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetUserQuery query)
        {
            return Ok(_executor.ExecuteQuery(query,id));
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserInfoDto dto, [FromServices] IUpdateUserCommand command)
        {
            dto.Id = id;
            dto.Password = _hash.ComputeSha256Hash(dto.Password);
            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }
        [HttpPost("usergroup")]
        public IActionResult UserGroup([FromBody] UserGroupDto dto, [FromServices] ICreateUserGroupCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(201);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,[FromServices] IDeleteUserCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }

        [HttpDelete("/api/users/{userId}/usergroup/{groupId}")]
        public IActionResult RemoveUserGroup(int userId, int groupId, [FromServices] IDeleteUserGroupCommand command)
        {
            _executor.ExecuteCommand(command, userId, groupId);
            return NoContent();
        }
    }
}
