using BugStore.Models;

namespace BugStore.Responses.Orders
{
    public class CreateOrdersResponse
    {
        public Order? Order { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }
}
