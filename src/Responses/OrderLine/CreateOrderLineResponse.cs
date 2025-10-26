using BugStore.Models;

namespace BugStore.Responses.OrderLines
{
    public class CreateOrderLineResponse
    {
        public OrderLine? OrderLine { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }
}
