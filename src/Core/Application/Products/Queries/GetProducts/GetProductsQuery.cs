using Application.Products.Queries.GetProductById;
using Domain.Responses.Api;
using Domain.Responses.Products;
using MediatR;


namespace Application.Products.Queries.GetProducts
{
    public record GetProductsQuery(string? searchTerm, int? maxPrice, int? minPrice) : IRequest<ApiResponse<List<ProductResponse>>>;
}
