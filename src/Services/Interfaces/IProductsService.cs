using BugStore.Models;
using BugStore.Requests.Products;
using BugStore.Responses.Products;

namespace BugStore.Services.Interfaces
{
    public interface IProductsService
    {
        Task<GetByIdProductsResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<GetProductsResponse> GetAllAsync(CancellationToken cancellationToken);
        Task<CreateProductsResponse> CreateAsync(Product product, CancellationToken cancellationToken);
        Task<UpdateProductsResponse> UpdateProductAsync(UpdateProductsRequest request, CancellationToken cancellationToken);
        Task<DeleteProductsResponse> DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
