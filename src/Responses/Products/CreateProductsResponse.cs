using BugStore.Models;

namespace BugStore.Responses.Products
{
    public class CreateProductsResponse
    {
        public Product? Product { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }
}
