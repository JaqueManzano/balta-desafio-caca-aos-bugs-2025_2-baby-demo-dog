using BugStore.Models;

namespace BugStore.Responses.Customers
{
    public class UpdateCustomerResponse
    {
        public Customer? Customer { get; set; }
        public bool Success { get; set; }
        public string? Message { get; set; }
    }
}
