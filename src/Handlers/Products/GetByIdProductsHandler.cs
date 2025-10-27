using BugStore.Requests.Products;
using BugStore.Responses.Products;
using BugStore.Services.Interfaces;
using MediatR;

namespace BugStore.Handlers.Products
{
    public class GetByIdProductHandler(IProductsService _service) : IRequestHandler<GetByIdProductsRequest, GetByIdProductsResponse>
    {
        public async Task<GetByIdProductsResponse> Handle(GetByIdProductsRequest request, CancellationToken cancellationToken)
        {
            return await _service.GetByIdAsync(request.Id, cancellationToken);
        }
    }
}
