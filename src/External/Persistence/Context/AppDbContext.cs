using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public class AppDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                 new List<Category>()
                 {
                     new Category() { Id = 1,Name="test1"},
                     new Category() { Id = 2,Name="test2"},
                     new Category() { Id = 3,Name="test3"}, 
                 }
                );
        }
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
