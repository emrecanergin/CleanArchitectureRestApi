using Application.Repositories;
using AutoMapper;
using Domain.Exceptions.Product;
using Domain.Responses.Api;
using Domain.Responses.Products;
using MediatR;


namespace Application.Products.Queries.GetProductById
{
    internal class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ApiResponse<ProductResponse>>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public GetProductByIdQueryHandler(IProductRepository repository,
                                          IMapper mapper)
        {
             _repository = repository;
            _mapper = mapper;
        }
        public async Task<ApiResponse<ProductResponse>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _repository.FindByIdAsync(request.id);
            if (product is null)
                throw new ProductNotFoundException(request.id);
            var mappedProduct = _mapper.Map(product, new ProductResponse());
            return new ApiResponse<ProductResponse>(mappedProduct);
        }
    }
}
