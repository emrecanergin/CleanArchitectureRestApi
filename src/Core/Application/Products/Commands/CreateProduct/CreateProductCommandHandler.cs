using Application.RabbitMq;
using Application.Repositories;
using Domain.Entities;
using Domain.Responses.Api;
using Domain.Responses.Products;
using MediatR;


namespace Application.Products.Commands.CreateProduct
{
    internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand,ApiResponse<object>>
    {
        private readonly IProductRepository _repository;
        private readonly IPublisherService _publisherService;
        public CreateProductCommandHandler(IProductRepository repository,
                                           IPublisherService  publisherService)
        {
            _repository = repository;
            _publisherService = publisherService;
        }
        public async Task<ApiResponse<object>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product()
            {
                Name = request.name,
                CategoryId = request.categoryId,
                Stock = request.stock,
                Price = request.price,
            };
            await _repository.AddAsync(product);
            _publisherService.SendMessage("rabbit","product",product);
            return new ApiResponse<object>(true,"product created succesfully");
        }
    }
}
