using BugStore.Requests.Orders;
using BugStore.Responses.Orders;

namespace BugStore.Services.Interfaces
{
    public interface IOrderService
    {
        Task<GetByIdOrdersResponse> GetOrderByIdAsync(GetByIdOrdersRequest request, CancellationToken cancellationToken);
        Task<CreateOrdersResponse> CreateOrderAsync(CreateOrdersRequest request, CancellationToken cancellationToken);
    }
}
