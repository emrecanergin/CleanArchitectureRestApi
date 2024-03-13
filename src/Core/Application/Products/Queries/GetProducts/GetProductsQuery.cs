using Application.Products.Queries.GetProductById;
using Domain.Responses.Api;
using Domain.Responses.Products;
using MediatR;


namespace Application.Products.Queries.GetProducts
{
    public class GetProductsQuery : IRequest<ApiResponse<List<ProductResponse>>>;
}
