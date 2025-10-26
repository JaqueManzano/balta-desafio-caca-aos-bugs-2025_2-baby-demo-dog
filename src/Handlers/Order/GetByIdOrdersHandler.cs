using BugStore.Data;
using BugStore.Requests.Orders;
using BugStore.Responses.Orders;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BugStore.Handlers.Orders
{
    public class GetByIdOrdersHandler(AppDbContext _context) : IRequestHandler<GetByIdOrdersRequest, GetByIdOrdersResponse>
    {
        public async Task<GetByIdOrdersResponse> Handle(GetByIdOrdersRequest request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Lines)
                    .ThenInclude(l => l.Product)
                .FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken);

            if (order == null)
                return new GetByIdOrdersResponse { Order = null, Message = "Order not found." };

            return new GetByIdOrdersResponse { Order = order, Message = "Order found." };
        }
    }
}
