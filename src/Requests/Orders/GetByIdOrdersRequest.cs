using BugStore.Responses.Orders;
using MediatR;

namespace BugStore.Requests.Orders
{
    public class GetByIdOrdersRequest : IRequest<GetByIdOrdersResponse>
    {
        public Guid Id { get; set; }
    }
}
