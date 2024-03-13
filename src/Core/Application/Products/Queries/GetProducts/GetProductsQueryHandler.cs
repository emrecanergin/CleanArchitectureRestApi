using Application.Repositories;
using AutoMapper;
using Domain.Responses.Api;
using Domain.Responses.Products;
using MediatR;


namespace Application.Products.Queries.GetProducts
{
    internal class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, ApiResponse<List<ProductResponse>>>
    {
        private readonly IProductRepository _repository;
        public GetProductsQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<ApiResponse<List<ProductResponse>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetProducts(request.searchTerm,request.maxPrice,request.minPrice);
            return new ApiResponse<List<ProductResponse>>(data);
        }
    }
}
