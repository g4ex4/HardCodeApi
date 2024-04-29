using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.EntityTypeConfigurations
{
    public class CategoryFieldConfig : IEntityTypeConfiguration<CategoryField>
    {
        public void Configure(EntityTypeBuilder<CategoryField> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Name)
                .HasMaxLength(50);
            
            builder.Property(x => x.Value)
                .HasMaxLength(50);
            
            builder.HasOne(x => x.Category)
                .WithMany(c => c.CategoryFields)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
