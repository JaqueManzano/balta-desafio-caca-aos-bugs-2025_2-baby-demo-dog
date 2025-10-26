using BugStore.Data;
using BugStore.Models;
using BugStore.Requests.Customers;
using BugStore.Responses.Customers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BugStore.Handlers.Customers
{
    public class GetCustomerHandler(AppDbContext _context) : IRequestHandler<GetCustomerRequest, GetCustomerResponse>
    {
        public async Task<GetCustomerResponse> Handle(GetCustomerRequest request, CancellationToken cancellationToken)
        {
            try
            {
                List<Customer> customers = await _context.Customers.AsNoTracking().ToListAsync();

                if (customers.Any())
                {
                    return new GetCustomerResponse
                    {
                        Customers = customers,
                        Success = true
                    };
                }

                return new GetCustomerResponse
                {
                    Customers = new(),
                    Success = true,
                    Message = $"No registered clients."
                };
            }
            catch (Exception)
            {
                return new GetCustomerResponse
                {
                    Customers = new(),
                    Success = false,
                    Message = $"It was not possible to search for registered customers."
                };
            }
        }
    }
}
