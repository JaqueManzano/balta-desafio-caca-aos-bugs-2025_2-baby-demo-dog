using BugStore.Responses.Products;
using MediatR;

namespace BugStore.Requests.Products
{
    public class GetByIdProductsRequest : IRequest<GetByIdProductsResponse>
    {
        public Guid Id { get; set; }
    }
}
