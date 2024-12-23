using ERPServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERPServer.Infrastructure.Persistence.Configurations;

public sealed class EquipmentConfiguration : IEntityTypeConfiguration<Equipment>
{
    public void Configure(EntityTypeBuilder<Equipment> builder)
    {
        builder.ToTable("Equipments");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedNever() 
            .IsRequired();

        builder.Property(e => e.Name)
            .HasMaxLength(100) 
            .IsRequired(); 

        builder.Property(e => e.SerialNumber)
            .HasMaxLength(50) 
            .IsRequired(); 

        builder.Property(e => e.Type)
            .HasMaxLength(50) 
            .IsRequired(); 
    }
}
