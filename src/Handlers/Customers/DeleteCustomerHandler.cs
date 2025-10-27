using BugStore.Requests.Customers;
using BugStore.Responses.Customers;
using BugStore.Services.Interfaces;
using MediatR;

namespace BugStore.Handlers.Customers
{
    public class DeleteCustomerHandler(ICustomerService _service) : IRequestHandler<DeleteCustomerRequest, DeleteCustomerResponse>
    {
        public async Task<DeleteCustomerResponse> Handle(DeleteCustomerRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var (success, message) = await _service.DeleteCustomerAsync(request.Id, cancellationToken);

                return new DeleteCustomerResponse
                {
                    Success = success,
                    Message = message
                };
            }
            catch (Exception)
            {
                return new DeleteCustomerResponse
                {
                    Success = false,
                    Message = "The customer could not be deleted."
                };
            }
        }
    }
}
