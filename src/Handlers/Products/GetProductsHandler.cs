using BugStore.Data;
using BugStore.Requests.Products;
using BugStore.Responses.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetProductHandler (AppDbContext _context) : IRequestHandler<GetProductsRequest, GetProductsResponse>
{
    public async Task<GetProductsResponse> Handle(GetProductsRequest request, CancellationToken cancellationToken)
    {
        var products = await _context.Products.ToListAsync(cancellationToken);
        return new GetProductsResponse { Products = products, Success = true };
    }
}