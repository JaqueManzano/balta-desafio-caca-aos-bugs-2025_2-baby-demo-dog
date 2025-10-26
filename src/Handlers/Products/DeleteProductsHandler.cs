using BugStore.Data;
using BugStore.Requests.Products;
using BugStore.Responses.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class DeleteProductsHandler(AppDbContext _context) : IRequestHandler<DeleteProductsRequest, DeleteProductsResponse>
{
    public async Task<DeleteProductsResponse> Handle(DeleteProductsRequest request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
        if (product == null)
            return new DeleteProductsResponse { Success = false, Message = "Product not found." };

        _context.Products.Remove(product);
        await _context.SaveChangesAsync(cancellationToken);

        return new DeleteProductsResponse { Success = true, Message = "Product deleted successfully." };
    }
}