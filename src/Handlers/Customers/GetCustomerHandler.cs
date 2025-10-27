using BugStore.Requests.Customers;
using BugStore.Responses.Customers;
using BugStore.Services.Interfaces;
using MediatR;

namespace BugStore.Handlers.Customers
{
    public class GetCustomerHandler(ICustomerService _service) : IRequestHandler<GetCustomerRequest, GetCustomerResponse>
    {
        public async Task<GetCustomerResponse> Handle(GetCustomerRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var (customers, success, message) = await _service.GetAllCustomersAsync(cancellationToken);

                return new GetCustomerResponse
                {
                    Customers = customers,
                    Success = success,
                    Message = message
                };
            }
            catch (Exception)
            {
                return new GetCustomerResponse
                {
                    Customers = new(),
                    Success = false,
                    Message = "It was not possible to search for registered customers."
                };
            }
        }
    }
}
