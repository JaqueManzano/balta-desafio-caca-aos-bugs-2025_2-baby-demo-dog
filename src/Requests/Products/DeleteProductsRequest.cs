using BugStore.Responses.Products;
using MediatR;

namespace BugStore.Requests.Products
{
    public class DeleteProductsRequest : IRequest<DeleteProductsResponse>
    {
        public Guid Id { get; set; }
    }
}
