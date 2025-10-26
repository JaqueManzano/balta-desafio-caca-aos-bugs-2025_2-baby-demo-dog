using BugStore.Models;

namespace BugStore.Responses.Products
{
    public class GetProductsResponse
    {
        public List<Product> Products { get; set; } = new();
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
