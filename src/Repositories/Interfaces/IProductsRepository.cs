using BugStore.Models;

namespace BugStore.Repositories.Interfaces
{
    public interface IProductsRepository
    {
        Task<Product?> GetBySlugAsync(string slug, CancellationToken cancellationToken);
        Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<List<Product>> GetAllAsync(CancellationToken cancellationToken);
        Task AddAsync(Product product, CancellationToken cancellationToken);
        Task UpdateAsync(Product product, CancellationToken cancellationToken);
        Task DeleteAsync(Product product, CancellationToken cancellationToken);
    }
}
