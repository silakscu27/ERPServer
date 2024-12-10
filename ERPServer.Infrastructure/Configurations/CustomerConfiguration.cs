using ERPServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERPServer.Infrastructure.Configurations
{
    public sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.PhoneNumber)
                .HasMaxLength(15);

            builder.Property(c => c.Email)
                .HasMaxLength(150);

            builder.Property(c => c.TaxDepartment)
                .HasMaxLength(100);

            builder.Property(c => c.TaxNumber)
                .HasMaxLength(50);

            builder.Property(c => c.City)
                .HasMaxLength(100);

            builder.Property(c => c.Town)
                .HasMaxLength(100);

            builder.Property(c => c.FullAddress)
                .HasMaxLength(250);

            builder.HasMany(c => c.OrderCustomers)
                   .WithOne(oc => oc.Customer)
                   .HasForeignKey(oc => oc.CustomerId);
        }
    }
}
