using BugStore.Data;
using BugStore.Requests.Products;
using BugStore.Responses.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetByIdProductHandler : IRequestHandler<GetByIdProductsRequest, GetByIdProductsResponse>
{
    private readonly AppDbContext _context;
    public GetByIdProductHandler(AppDbContext context) => _context = context;

    public async Task<GetByIdProductsResponse> Handle(GetByIdProductsRequest request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
        if (product == null)
            return new GetByIdProductsResponse { Product = null, Message = "Product not found." };

        return new GetByIdProductsResponse { Product = product, Message = "Product found." };
    }
}