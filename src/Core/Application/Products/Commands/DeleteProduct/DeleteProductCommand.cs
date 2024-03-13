using Domain.Responses.Api;
using MediatR;


namespace Application.Products.Commands.DeleteProduct
{
    public record DeleteProductCommand(int id) : IRequest<ApiResponse<object>>;
}
