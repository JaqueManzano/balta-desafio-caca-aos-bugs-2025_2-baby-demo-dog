using BugStore.Data;
using BugStore.Models;
using BugStore.Requests.Orders;
using BugStore.Responses.Orders;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BugStore.Handlers.Orders
{
    public class CreateOrdersHandler(AppDbContext _context) : IRequestHandler<CreateOrdersRequest, CreateOrdersResponse>
    {
        public async Task<CreateOrdersResponse> Handle(CreateOrdersRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == request.CustomerId, cancellationToken);
                if (customer == null)
                    return new CreateOrdersResponse { Success = false, Message = "Customer not found." };

                var order = new Models.Order
                {
                    CustomerId = customer.Id,
                    Customer = customer,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                foreach (var lineDto in request.Lines)
                {
                    var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == lineDto.ProductId, cancellationToken);
                    if (product == null) continue;

                    var orderLine = new OrderLine
                    {
                        ProductId = product.Id,
                        Product = product,
                        Quantity = lineDto.Quantity,
                        Total = product.Price * lineDto.Quantity,
                        OrderId = order.Id
                    };

                    order.Lines.Add(orderLine);
                    _context.OrderLines.Add(orderLine);
                }

                _context.Orders.Add(order);
                await _context.SaveChangesAsync(cancellationToken);

                return new CreateOrdersResponse { Order = order };
            }
            catch
            {
                return new CreateOrdersResponse { Success = false, Message = "The order could not be created." };
            }
        }
    }
}
