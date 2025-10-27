using BugStore.Requests.Products;
using BugStore.Responses.Products;
using BugStore.Services.Interfaces;
using MediatR;

namespace BugStore.Handlers.Products
{
    public class GetProductsHandler(IProductsService _service) : IRequestHandler<GetProductsRequest, GetProductsResponse>
    {
        public async Task<GetProductsResponse> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {
            return await _service.GetAllAsync(cancellationToken);
        }
    }
}
