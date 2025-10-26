using BugStore.Models;

namespace BugStore.Responses.Customers;

public class CreateCustomerResponse
{
    public Customer? Customer {  get; set; }
    public bool Success { get; set; } = true;
    public string Message { get; set; } = string.Empty;
}