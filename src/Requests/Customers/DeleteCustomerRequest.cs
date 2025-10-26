using MediatR;
using BugStore.Responses.Customers;

namespace BugStore.Requests.Customers;

public class DeleteCustomerRequest : IRequest<DeleteCustomerResponse>
{
    public Guid Id { get; set; }
}
