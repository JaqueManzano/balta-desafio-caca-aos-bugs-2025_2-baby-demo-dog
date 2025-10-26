using BugStore.Models;

namespace BugStore.Responses.Customers;

public class GetByIdCustomerResponse
{
    public Customer? Customer {  get; set; }
    public string Message { get; set; } = string.Empty;
}