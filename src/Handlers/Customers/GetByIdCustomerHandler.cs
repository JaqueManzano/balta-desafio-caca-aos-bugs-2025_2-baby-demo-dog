using BugStore.Data;
using BugStore.Requests.Customers;
using BugStore.Responses.Customers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BugStore.Handlers.Customers
{
    public class GetByIdCustomerHandler(AppDbContext _context) : IRequestHandler<GetByIdCustomerRequest, GetByIdCustomerResponse>
    {
        public async Task<GetByIdCustomerResponse> Handle(GetByIdCustomerRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var customer = await _context.Customers
            .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

                if (customer == null)
                {
                    return new GetByIdCustomerResponse
                    {
                        Customer = null,
                        Message = $"Customer with ID {request.Id} not found."
                    };
                }

                return new GetByIdCustomerResponse
                {
                    Customer = customer,
                    Message = $"Customer with ID {request.Id} found."
                };
            }
            catch (Exception)
            {
                return new GetByIdCustomerResponse
                {
                    Customer = null,
                    Message = $"The client could not be consulted."
                };
            }
        }
    }
}
