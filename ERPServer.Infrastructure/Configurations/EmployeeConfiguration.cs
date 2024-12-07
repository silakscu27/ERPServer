using ERPServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERPServer.Infrastructure.Persistence.Configurations;

public sealed class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        // Tablo adı
        builder.ToTable("Employees");

        // Primary key
        builder.HasKey(e => e.Id);

        // ID alanı
        builder.Property(e => e.Id)
            .ValueGeneratedNever() // GUID manuel atanır
            .IsRequired();

        // FirstName alanı
        builder.Property(e => e.FirstName)
            .HasMaxLength(50) // Maksimum uzunluk
            .IsRequired(); // Boş olamaz

        // LastName alanı
        builder.Property(e => e.LastName)
            .HasMaxLength(50)
            .IsRequired();

        // Position alanı
        builder.Property(e => e.Position)
            .HasMaxLength(100)
            .IsRequired();

        // DepartmentId alanı
        builder.Property(e => e.DepartmentId)
            .IsRequired();

        // HireDate alanı
        builder.Property(e => e.HireDate)
            .IsRequired();

        // Salary alanı
        builder.Property(e => e.Salary)
            .HasColumnType("decimal(18,2)") // Maaş için uygun veri tipi
            .IsRequired();

        // İlişki (Foreign Key)
        builder.HasOne(e => e.Department) // Employee -> Department
            .WithMany(d => d.Employees) // Department -> Employees
            .HasForeignKey(e => e.DepartmentId) // Foreign key tanımı
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete
    }
}
