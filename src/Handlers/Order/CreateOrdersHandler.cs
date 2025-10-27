using BugStore.Requests.Orders;
using BugStore.Responses.Orders;
using BugStore.Services.Interfaces;
using MediatR;

public class CreateOrdersHandler(IOrderService _service) : IRequestHandler<CreateOrdersRequest, CreateOrdersResponse>
{
    public async Task<CreateOrdersResponse> Handle(CreateOrdersRequest request, CancellationToken cancellationToken)
    {
        return await _service.CreateOrderAsync(request, cancellationToken);
    }
}
