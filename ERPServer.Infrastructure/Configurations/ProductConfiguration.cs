using ERPServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERPServer.Infrastructure.Configurations;

public sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .IsRequired() 
            .HasMaxLength(200); 

        builder.Property(p => p.Price)
            .IsRequired() 
            .HasColumnType("decimal(18,2)"); 

        builder.HasOne(p => p.Stock)
            .WithMany(s => s.Products)
            .HasForeignKey(p => p.StockId)
            .OnDelete(DeleteBehavior.Cascade); 
    }
}
