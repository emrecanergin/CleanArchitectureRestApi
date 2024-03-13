using Application.Repositories;
using Domain.Exceptions.Product;
using Domain.Responses.Api;
using MediatR;

namespace Application.Products.Commands.DeleteProduct
{
    internal class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ApiResponse<object>>
    {
        private readonly IProductRepository _repository;
        public DeleteProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<ApiResponse<object>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.FindByIdAsync(request.id);
            if (product is null) 
                throw new ProductNotFoundException(request.id);

            await _repository.DeleteAsync(product);
            return new ApiResponse<object>(true, $"product with {request.id} has been deleted succesfully");
        }
    }
}
