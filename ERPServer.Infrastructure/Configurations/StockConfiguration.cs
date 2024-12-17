using ERPServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERPServer.Infrastructure.Configurations
{
    public sealed class StockConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.ToTable("Stocks");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.ProductName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(s => s.Quantity)
                .IsRequired();

            builder.Property(s => s.Price)
                .IsRequired()
                .HasPrecision(18, 2);

            builder.Property(s => s.LastUpdatedDate)
                .IsRequired();

            builder.HasOne(s => s.Category)
                   .WithMany(c => c.Stocks)
                   .HasForeignKey(s => s.CategoryId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
