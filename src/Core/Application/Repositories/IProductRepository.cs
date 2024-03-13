using Domain.Entities;
using Domain.Responses.Products;

namespace Application.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<List<ProductResponse>> GetProductsAsProductResponse();
        Task<Product> FindByIdAsync(int id);
    }
}
