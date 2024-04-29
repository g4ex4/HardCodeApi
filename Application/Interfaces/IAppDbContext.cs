using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IAppDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryField> CategoriesField { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
