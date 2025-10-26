using BugStore.Data;
using BugStore.Models;
using BugStore.Requests.Products;
using BugStore.Responses.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BugStore.Handlers.Products
{
    public class CreateProductsHandler(AppDbContext _context) : IRequestHandler<CreateProductsRequest, CreateProductsResponse>
    {
        public async Task<CreateProductsResponse> Handle(CreateProductsRequest request, CancellationToken cancellationToken)
        {
            var exists = await _context.Products.FirstOrDefaultAsync(p => p.Slug == request.Slug, cancellationToken);
            if (exists != null)
                return new CreateProductsResponse
                {
                    Product = exists,
                    Success = false,
                    Message = "Product already registered."
                };

            var product = new Product
            {
                Title = request.Title,
                Description = request.Description,
                Slug = request.Slug,
                Price = request.Price
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync(cancellationToken);

            return new CreateProductsResponse { Product = product };
        }
    }
}
