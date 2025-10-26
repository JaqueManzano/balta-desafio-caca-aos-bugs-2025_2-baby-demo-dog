using BugStore.Requests.Customers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BugStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _mediator.Send(new GetByIdCustomerRequest { Id = id });
            return response is null ? NotFound() : Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new GetCustomerRequest());
            return response.Success ? Ok(response) : BadRequest(response.Message);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateCustomerRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(UpdateCustomerRequest request)
        {
            var response = await _mediator.Send(request);
            return response.Success ? Ok(response) : BadRequest(response.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteCustomerRequest { Id = id });

            return result.Success ? Ok(result) : NotFound(result.Message);
        }
    }
}
