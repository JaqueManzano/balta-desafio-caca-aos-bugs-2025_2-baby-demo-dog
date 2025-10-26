using BugStore.Responses.Customers;
using MediatR;

namespace BugStore.Requests.Customers;

public class GetCustomerRequest : IRequest<GetCustomerResponse>
{
}