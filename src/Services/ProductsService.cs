using BugStore.Models;
using BugStore.Repositories.Interfaces;
using BugStore.Requests.Products;
using BugStore.Responses.Products;
using BugStore.Services.Interfaces;

namespace BugStore.Services.Products
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _repository;

        public ProductsService(IProductsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetByIdProductsResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(id, cancellationToken);
            if (product == null)
            {
                return new GetByIdProductsResponse
                {
                    Product = null,
                    Message = "Product not found."
                };
            }

            return new GetByIdProductsResponse
            {
                Product = product,
                Message = "Product found."
            };
        }

        public async Task<GetProductsResponse> GetAllAsync(CancellationToken cancellationToken)
        {
            var products = await _repository.GetAllAsync(cancellationToken);

            if (products == null || products.Count == 0)
            {
                return new GetProductsResponse
                {
                    Products = new(),
                    Success = true,
                    Message = "No registered products."
                };
            }

            return new GetProductsResponse
            {
                Products = products,
                Success = true
            };
        }


        public async Task<CreateProductsResponse> CreateAsync(Product product, CancellationToken cancellationToken)
        {
            var exists = await _repository.GetBySlugAsync(product.Slug, cancellationToken);

            if (exists != null)
            {
                return new CreateProductsResponse
                {
                    Product = exists,
                    Success = false,
                    Message = "Product already registered."
                };
            }

            await _repository.AddAsync(product, cancellationToken);

            return new CreateProductsResponse
            {
                Product = product,
                Success = true,
                Message = "Product created successfully."
            };
        }

        public async Task<UpdateProductsResponse> UpdateProductAsync(UpdateProductsRequest request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id, cancellationToken);
            if (product == null)
                return new UpdateProductsResponse { Success = false, Message = "Product not found." };

            if (!string.IsNullOrEmpty(request.Title)) product.Title = request.Title;
            if (!string.IsNullOrEmpty(request.Description)) product.Description = request.Description;
            if (!string.IsNullOrEmpty(request.Slug)) product.Slug = request.Slug;
            if (request.Price.HasValue) product.Price = request.Price.Value;

            await _repository.UpdateAsync(product, cancellationToken);

            return new UpdateProductsResponse { Product = product, Success = true, Message = "Product updated successfully." };
        }

        public async Task<DeleteProductsResponse> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(id, cancellationToken);
            if (product == null)
            {
                return new DeleteProductsResponse
                {
                    Success = false,
                    Message = "Product not found."
                };
            }

            await _repository.DeleteAsync(product, cancellationToken);

            return new DeleteProductsResponse
            {
                Success = true,
                Message = "Product deleted successfully."
            };
        }
    }
}
