using Application.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories.Products
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        protected AppDbContext _context { get; set; }
        public ProductRepository(AppDbContext context) : base(context)
        {
                
        }
    }
}
