using BugStore.Responses.Customers;
using MediatR;

namespace BugStore.Requests.Customers;

public class GetByIdCustomerRequest : IRequest<GetByIdCustomerResponse>
{
    public Guid Id { get; set; }
}