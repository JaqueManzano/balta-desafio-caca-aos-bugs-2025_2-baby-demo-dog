using BugStore.Responses.Products;
using MediatR;

namespace BugStore.Requests.Products
{
    public class GetProductsRequest : IRequest<GetProductsResponse>
    {
    }
}
