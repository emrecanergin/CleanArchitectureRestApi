using Domain.Responses.Api;
using MediatR;


namespace Application.Products.Commands.UpdateProduct
{
    public record UpdateProductCommand(
        int id,
        string name,
        int stock,
        decimal price) : IRequest<ApiResponse<object>>;
}
