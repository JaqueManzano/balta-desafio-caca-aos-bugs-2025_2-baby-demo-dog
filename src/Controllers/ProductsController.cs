using BugStore.Requests.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BugStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _mediator.Send(new GetByIdProductsRequest { Id = id });
            return response.Product is null ? NotFound(response.Message) : Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new GetProductsRequest());
            return response.Success ? Ok(response) : BadRequest(response.Message);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateProductsRequest request)
        {
            var response = await _mediator.Send(request);
            return response.Success ? Ok(response) : BadRequest(response.Message);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(UpdateProductsRequest request)
        {
            var response = await _mediator.Send(request);
            return response.Success ? Ok(response) : BadRequest(response.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _mediator.Send(new DeleteProductsRequest { Id = id });
            return response.Success ? Ok(response) : NotFound(response.Message);
        }
    }
}
