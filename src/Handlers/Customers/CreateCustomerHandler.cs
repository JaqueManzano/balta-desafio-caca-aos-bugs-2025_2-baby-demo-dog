using BugStore.Requests.Customers;
using BugStore.Responses.Customers;
using BugStore.Services.Interfaces;
using MediatR;

namespace BugStore.Handlers.Customers
{
    public class CreateCustomerHandler(ICustomerService _service) : IRequestHandler<CreateCustomerRequest, CreateCustomerResponse>
    {
        public async Task<CreateCustomerResponse> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var (customer, success, message) = await _service.CreateCustomerAsync(
                    request.Name,
                    request.Email,
                    request.Phone,
                    request.BirthDate,
                    cancellationToken
                );

                return new CreateCustomerResponse
                {
                    Customer = customer,
                    Success = success,
                    Message = message
                };
            }
            catch (Exception)
            {
                return new CreateCustomerResponse
                {
                    Customer = null,
                    Success = false,
                    Message = "The customer could not be registered."
                };
            }
        }
    }
}
