using Application.Repositories;
using Domain.Exceptions.Product;
using Domain.Responses.Api;
using MediatR;


namespace Application.Products.Commands.UpdateProduct
{
    internal class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ApiResponse<object>>
    {
        private readonly IProductRepository _repository;
        public UpdateProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<ApiResponse<object>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.FindByIdAsync(request.id);
            if (product is null)
                throw new ProductNotFoundException(request.id);
            product.Name = request.name;
            product.Stock = request.stock;  
            product.Price = request.price;
            await _repository.UpdateAsync(product);
            return new ApiResponse<object>(true, $"product with {request.id} has been updated succesfully");
        }
    }
}
