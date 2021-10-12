using Application;
using Application.Commands.Comments;
using Application.Commands.Products;
using Application.Commands.Ratings;
using Application.DataTransfer;
using Application.DataTransfer.ProductsDto;
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
    public class ProductsController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public ProductsController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public IActionResult Get([FromQuery] ProductSearch search, [FromServices] IGetProductsQuery query)
        {
            return Ok(_executor.ExecuteQuery(query,search));
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id,[FromServices] IGetProductQuery query)
        {
            return Ok(_executor.ExecuteQuery(query,id));
        }
        [Authorize]
        [HttpPost("/api/products/ratings")]
        public IActionResult RateProducts([FromBody] RatingDto dto, [FromServices] ICreateRatingCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(201);
        }

        [Authorize]
        [HttpPost("api/products/comments")]
        public IActionResult AddComment([FromBody] CommentDto dto, [FromServices] ICreateCommentCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(201);
        }

        [Authorize]
        [HttpDelete("api/products/comments/{id}")]
        public IActionResult DeleteComment(int id, [FromServices] IDeleteCommentCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return StatusCode(201);
        }

        // POST api/<ProductsController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] ProductDto dto, [FromServices] ICreateProductCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<ProductsController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProductDto dto, [FromServices] IUpdateProductCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE api/<ProductsController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteProductCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
