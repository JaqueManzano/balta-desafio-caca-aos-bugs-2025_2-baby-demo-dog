using BugStore.Models;
using BugStore.Requests.Customers;
using BugStore.Responses.Customers;
using BugStore.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BugStore.Handlers.Customers
{
    public class CreateCustomerHandler(AppDbContext _context) : IRequestHandler<CreateCustomerRequest, CreateCustomerResponse>
    {
        public async Task<CreateCustomerResponse> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var exists = await _context.Customers
                               .FirstOrDefaultAsync(c => c.Email == request.Email, cancellationToken);

                if (exists != null)
                    return new CreateCustomerResponse
                    {
                        Customer = exists,
                        Success = false,
                        Message = "Customer already registered."
                    };

                var customer = new Customer
                {
                    Name = request.Name,
                    Email = request.Email,
                    Phone = request.Phone,
                    BirthDate = request.BirthDate
                };

                _context.Customers.Add(customer);
                await _context.SaveChangesAsync(cancellationToken);

                return new CreateCustomerResponse
                {
                    Customer = customer
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
