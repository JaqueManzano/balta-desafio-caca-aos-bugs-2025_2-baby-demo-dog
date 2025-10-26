using BugStore.Data;
using BugStore.Requests.Customers;
using BugStore.Responses.Customers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BugStore.Handlers.Customers;

public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerRequest, DeleteCustomerResponse>
{
    private readonly AppDbContext _context;

    public DeleteCustomerHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<DeleteCustomerResponse> Handle(DeleteCustomerRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var customer = await _context.Customers
          .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (customer == null)
            {
                return new DeleteCustomerResponse
                {
                    Success = false,
                    Message = $"Customer with ID {request.Id} not found."
                };
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync(cancellationToken);

            return new DeleteCustomerResponse
            {
                Success = true,
                Message = $"Customer with ID {request.Id} successfully deleted."
            };
        }
        catch (Exception)
        {
            return new DeleteCustomerResponse
            {
                Success = false,
                Message = $"The client could not be deleted."
            };
        }

    }
}
