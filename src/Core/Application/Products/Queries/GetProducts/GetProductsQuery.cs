using Domain.Responses.Api;
using Domain.Responses.Products;
using MediatR;


namespace Application.Products.Queries.GetProducts
{
    public record GetProductsQuery(
        string? searchTerm, 
        int? maxPrice, 
        int? minPrice,
        int page,
        int pageSize) : IRequest<ApiResponse<PagedList<ProductResponse>>>;
}
