using BugStore.Models;

namespace BugStore.Responses.Customers;

public class GetCustomerResponse
{
    public List<Customer> Customers { get; set; } = new();
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
}