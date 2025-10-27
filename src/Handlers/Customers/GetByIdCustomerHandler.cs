using BugStore.Requests.Customers;
using BugStore.Responses.Customers;
using BugStore.Services.Interfaces;
using MediatR;

namespace BugStore.Handlers.Customers
{
    public class GetByIdCustomerHandler(ICustomerService _service) : IRequestHandler<GetByIdCustomerRequest, GetByIdCustomerResponse>
    {
        public async Task<GetByIdCustomerResponse> Handle(GetByIdCustomerRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var (customer, message) = await _service.GetCustomerByIdAsync(request.Id, cancellationToken);

                return new GetByIdCustomerResponse
                {
                    Customer = customer,
                    Message = message
                };
            }
            catch (Exception)
            {
                return new GetByIdCustomerResponse
                {
                    Customer = null,
                    Message = "The customer could not be consulted."
                };
            }
        }
    }
}
