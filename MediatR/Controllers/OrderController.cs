using MediatR.API.Commands.Orders;
using MediatR.API.Dtos;
using MediatR.API.Queries.Orders;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace MediatR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<OrderController> _logger;
        
        public OrderController(IMediator mediator, ILogger<OrderController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        
        // GET: api/<OrderController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var query = new GetAllOrdersQuery();
            var result = await _mediator.Send(query);

            _logger.LogInformation($"Get all orders at {DateTime.Now}");
            return Ok(result);
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            OrderReadDto result;

            try
            {
                var query = new GetOrderByIdQuery(id);
                result = await _mediator.Send(query);
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Get order by id {id} failed!");
                return NotFound(ex.Message);
            }

            _logger.LogInformation($"Get order by id {id} success!");
            return Ok(result);
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderCreateDto orderDto)
        {
            OrderReadDto result;
            try
            {
                var query = new CreateOrderCommand(orderDto);
                result = await _mediator.Send(query);
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Order not created!");
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }

            _logger.LogInformation($"Order created with id {result.OrderId}!");
            return StatusCode(StatusCodes.Status201Created, result);
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] OrderCreateDto orderDto)
        {
            OrderReadDto result;

            try
            {
                var query = new UpdateOrderCommand(id, orderDto);
                result = await _mediator.Send(query);
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Order with id {id} not updated!");
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }

            _logger.LogInformation($"Order with id {id} updated!");
            return StatusCode(StatusCodes.Status200OK, result);
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            OrderReadDto result;
            try
            {
                var query = new DeleteOrderCommand(id);
                result = await _mediator.Send(query);
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Order with id {id} not deleted!");
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }

            _logger.LogInformation($"Order with id {id} deleted!");
            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
