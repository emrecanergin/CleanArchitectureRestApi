using Application.Products.Queries.GetProducts;
using Domain.Entities;
using Domain.Responses.Products;

namespace Application.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<PagedList<ProductResponse>> GetProducts(
            string? searchTerm, 
            int? maxPrice, 
            int? minPrice,
            int page,
            int pageSize);
        Task<Product> FindByIdAsync(int id);
    }
}
