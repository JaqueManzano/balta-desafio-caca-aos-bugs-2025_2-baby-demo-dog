using BugStore.Requests.Orders;
using BugStore.Responses.Orders;
using BugStore.Services.Interfaces;
using MediatR;

namespace BugStore.Handlers.Orders
{
    public class GetByIdOrdersHandler(IOrderService _service) : IRequestHandler<GetByIdOrdersRequest, GetByIdOrdersResponse>
    {
        public async Task<GetByIdOrdersResponse> Handle(GetByIdOrdersRequest request, CancellationToken cancellationToken)
        {
            return await _service.GetOrderByIdAsync(request, cancellationToken);
        }
    }
}
