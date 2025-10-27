using BugStore.Models;
using BugStore.Requests.Products;
using BugStore.Responses.Products;
using BugStore.Services.Interfaces;
using MediatR;

namespace BugStore.Handlers.Products
{
    public class CreateProductsHandler(IProductsService _service) : IRequestHandler<CreateProductsRequest, CreateProductsResponse>
    {

        public async Task<CreateProductsResponse> Handle(CreateProductsRequest request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Title = request.Title,
                Description = request.Description,
                Slug = request.Slug,
                Price = request.Price
            };

            return await _service.CreateAsync(product, cancellationToken);
        }
    }
}
