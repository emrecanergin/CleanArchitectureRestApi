using Application.Repositories;
using Domain.Entities;
using Domain.Responses.Products;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories.Products
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        protected AppDbContext _context { get; set; }
        public ProductRepository(AppDbContext context) : base(context) 
        {
            _context = context; 
         
        }

        public Task<List<ProductResponse>> GetProductsAsProductResponse()
        {
            return _context.Products.Select(p => new ProductResponse
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Stock = p.Stock,
                Category = p.Category.Name,

            }).Include(i => i.Category).ToListAsync();
        }
        public async Task<Product> FindByIdAsync(int id)
        {
            return await _context.Products.Include(i => i.Category).FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
