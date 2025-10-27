using BugStore.Requests.Products;
using BugStore.Responses.Products;
using BugStore.Services.Interfaces;
using MediatR;

namespace BugStore.Handlers.Products
{
    public class DeleteProductsHandler(IProductsService _service) : IRequestHandler<DeleteProductsRequest, DeleteProductsResponse>
    {
        public async Task<DeleteProductsResponse> Handle(DeleteProductsRequest request, CancellationToken cancellationToken)
        {
            return await _service.DeleteAsync(request.Id, cancellationToken);
        }
    }
}
