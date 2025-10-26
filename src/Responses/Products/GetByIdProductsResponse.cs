using BugStore.Models;

namespace BugStore.Responses.Products
{
    public class GetByIdProductsResponse
    {
        public Product? Product { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
