using Application.Products.Queries.GetProducts;
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

        public async Task<PagedList<ProductResponse>> GetProducts(
            string? searchTerm,
            int? maxPrice,
            int? minPrice,
            int page,
            int pageSize)
        {
            IQueryable<Product> productsQuery = _context.Products;

            if(!string.IsNullOrWhiteSpace(searchTerm))
            {
                productsQuery = productsQuery.Where(p => p.Name.Contains(searchTerm));
            }
            if(maxPrice is not null)
            {
                productsQuery = productsQuery.Where(p => p.Price <= maxPrice);
            }
            if (minPrice is not null)
            {
                productsQuery = productsQuery.Where(p => p.Price >= minPrice);
            }


            var productsResponseQuery =  productsQuery
                .Include(i => i.Category)
                .Select(p => new ProductResponse
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Stock = p.Stock,
                    Category = p.Category.Name
                });

            var products = await PagedList<ProductResponse>.CreateAsync(
                productsResponseQuery, 
                page,
                pageSize);

            return products;
        }
        public async Task<Product> FindByIdAsync(int id)
        {
            return await _context.Products.Include(i => i.Category).FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
