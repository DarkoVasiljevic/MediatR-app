using MediatR.API.Commands.Users;
using MediatR.API.Dtos;
using MediatR.API.Queries.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace MediatR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
        }
        
        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var query = new GetAllUsersQuery();
            var result = await _mediator.Send(query);

            _logger.LogInformation($"Get all users at {DateTime.Now}");
            return Ok(result);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            UserReadDto result;

            try
            {
                var query = new GetUserByIdQuery(id);
                result = await _mediator.Send(query);
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Get user by id {id} failed!");
                return NotFound(ex.Message);
            }

            _logger.LogInformation($"Get user by id {id} success!");
            return Ok(result);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserCreateDto userDto)
        {
            UserReadDto result;
            try
            {
                var query = new CreateUserCommand(userDto);
                result = await _mediator.Send(query);
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"User not created!");
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }

            _logger.LogInformation($"User created with id {result.UserId}!");
            return StatusCode(StatusCodes.Status201Created, result);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UserCreateDto userDto)
        {
            UserReadDto result;
            try
            {
                var query = new UpdateUserCommand(id, userDto);
                result = await _mediator.Send(query);
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"User with id {id} not updated!");
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }

            _logger.LogInformation($"User with id {id} updated!");
            return StatusCode(StatusCodes.Status200OK, result);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            UserReadDto result;
            try
            {
                var query = new DeleteUserCommand(id);
                result = await _mediator.Send(query);
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"User with id {id} not deleted!");
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }

            _logger.LogInformation($"User with id {id} deleted!");
            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
