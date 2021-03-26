using Market.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Market.Infrastructure.Configurations
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasIndex(p => p.Name).IsUnique();
            builder.Property(p => p.DateCreated).ValueGeneratedOnAdd().HasDefaultValueSql("GETUTCDATE()");
            builder.Property(p => p.Name).HasMaxLength(50);
            builder.Property(p => p.Description).HasMaxLength(500);
            builder.Property(p => p.Price).HasColumnType("decimal(12,4)");
            builder.Property(p => p.Available).IsConcurrencyToken();
        }
    }
}
