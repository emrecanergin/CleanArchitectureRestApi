using Domain.Responses.Api;
using Domain.Responses.Products;
using MediatR;


namespace Application.Products.Queries.GetProductById
{
    public record GetProductByIdQuery(int id) : IRequest<ApiResponse<ProductResponse>>;
}
