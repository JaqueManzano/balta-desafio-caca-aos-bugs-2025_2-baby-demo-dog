using BugStore.Data;
using BugStore.Requests.Customers;
using BugStore.Responses.Customers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BugStore.Handlers.Customers
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerRequest, UpdateCustomerResponse>
    {
        private readonly AppDbContext _context;

        public UpdateCustomerHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UpdateCustomerResponse> Handle(UpdateCustomerRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var customer = await _context.Customers
             .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

                if (customer == null)
                {
                    return new UpdateCustomerResponse
                    {
                        Success = false,
                        Message = "Customer not found."
                    };
                }

                if (!string.IsNullOrEmpty(request.Name)) customer.Name = request.Name;
                if (!string.IsNullOrEmpty(request.Email)) customer.Email = request.Email;
                if (!string.IsNullOrEmpty(request.Phone)) customer.Phone = request.Phone;
                if (request.BirthDate.HasValue) customer.BirthDate = request.BirthDate.Value;

                await _context.SaveChangesAsync(cancellationToken);

                return new UpdateCustomerResponse
                {
                    Customer = customer,
                    Success = true,
                    Message = "Client successfully updated."
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
