using Domain.Responses.Api;
using Domain.Responses.Products;
using MediatR;


namespace Application.Products.Commands.CreateProduct
{
    public record CreateProductCommand(
     string name,
     int categoryId,
     int stock,
     decimal price) : IRequest<ApiResponse<object>>;
}
