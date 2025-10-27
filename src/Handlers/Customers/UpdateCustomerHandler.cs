using BugStore.Requests.Customers;
using BugStore.Responses.Customers;
using BugStore.Services.Interfaces;
using MediatR;

namespace BugStore.Handlers.Customers
{
    public class UpdateCustomerHandler(ICustomerService _service) : IRequestHandler<UpdateCustomerRequest, UpdateCustomerResponse>
    {
        public async Task<UpdateCustomerResponse> Handle(UpdateCustomerRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var (customer, success, message) = await _service.UpdateCustomerAsync(
                    request.Id,
                    request.Name,
                    request.Email,
                    request.Phone,
                    request.BirthDate,
                    cancellationToken
                );

                return new UpdateCustomerResponse
                {
                    Customer = customer,
                    Success = success,
                    Message = message
                };
            }
            catch (Exception)
            {
                return new UpdateCustomerResponse
                {
                    Customer = null,
                    Success = false,
                    Message = "Client could not be updated."
                };
            }
        }
    }
}
