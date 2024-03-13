using Domain.Entities;
using Domain.Responses.Products;

namespace Application.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<List<ProductResponse>> GetProducts(string? searchTerm, int? maxPrice, int? minPrice);
        Task<Product> FindByIdAsync(int id);
    }
}
