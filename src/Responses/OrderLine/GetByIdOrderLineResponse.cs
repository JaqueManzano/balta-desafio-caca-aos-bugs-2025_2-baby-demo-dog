using BugStore.Models;

namespace BugStore.Responses.OrderLines
{
    public class GetByIdOrderLineResponse
    {
        public OrderLine? OrderLine { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
