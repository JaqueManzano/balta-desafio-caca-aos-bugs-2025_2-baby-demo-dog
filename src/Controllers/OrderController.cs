using BugStore.Requests.Orders;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BugStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateOrdersRequest request)
        {
            var response = await _mediator.Send(request);
            return response.Success ? Ok(response) : BadRequest(response.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _mediator.Send(new GetByIdOrdersRequest { Id = id });
            return response.Order is null ? NotFound(response.Message) : Ok(response);
        }
    }
}
