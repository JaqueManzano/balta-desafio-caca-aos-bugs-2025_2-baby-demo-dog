using BugStore.Requests.Products;
using BugStore.Responses.Products;
using BugStore.Services.Interfaces;
using MediatR;

public class UpdateProductHandler(IProductsService _service) : IRequestHandler<UpdateProductsRequest, UpdateProductsResponse>
{
    public async Task<UpdateProductsResponse> Handle(UpdateProductsRequest request, CancellationToken cancellationToken)
    {
        return await _service.UpdateProductAsync(request, cancellationToken);
    }
}
