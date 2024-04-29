using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.EntityTypeConfigurations
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder.Property(x => x.Price)
                .HasColumnType("numeric(15,4)");
            
            builder.Property(x => x.Name)
                .HasMaxLength(50);
            
            builder.Property(x => x.Description)
                .HasMaxLength(500);
        }
    }
}
