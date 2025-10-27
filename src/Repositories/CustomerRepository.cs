using BugStore.Data;
using BugStore.Models;
using BugStore.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BugStore.Repositories.Customers
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Customer?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            if (id == Guid.Empty)
                return null;

            return await _context.Customers
                .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        }

        public async Task<List<Customer>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Customers
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<Customer?> GetByEmailAsync(string email, CancellationToken cancellationToken)
        {
            return await _context.Customers
                .FirstOrDefaultAsync(c => c.Email == email, cancellationToken);
        }

        public async Task AddAsync(Customer customer, CancellationToken cancellationToken)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Customer customer, CancellationToken cancellationToken)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync(cancellationToken);
        }


        public async Task RemoveAsync(Customer customer, CancellationToken cancellationToken)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync(cancellationToken);
        }

    }
}
