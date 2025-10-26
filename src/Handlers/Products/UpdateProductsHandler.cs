using BugStore.Data;
using BugStore.Requests.Products;
using BugStore.Responses.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class UpdateProductHandler : IRequestHandler<UpdateProductsRequest, UpdateProductsResponse>
{
    private readonly AppDbContext _context;
    public UpdateProductHandler(AppDbContext context) => _context = context;

    public async Task<UpdateProductsResponse> Handle(UpdateProductsRequest request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
        if (product == null)
            return new UpdateProductsResponse { Success = false, Message = "Product not found." };

        if (!string.IsNullOrEmpty(request.Title)) product.Title = request.Title;
        if (!string.IsNullOrEmpty(request.Description)) product.Description = request.Description;
        if (!string.IsNullOrEmpty(request.Slug)) product.Slug = request.Slug;
        if (request.Price.HasValue) product.Price = request.Price.Value;

        await _context.SaveChangesAsync(cancellationToken);

        return new UpdateProductsResponse { Product = product, Success = true, Message = "Product updated successfully." };
    }
}
