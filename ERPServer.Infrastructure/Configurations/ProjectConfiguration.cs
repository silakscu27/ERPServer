using ERPServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERPServer.Infrastructure.Configurations;

public sealed class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.ToTable("Projects"); 

        builder.HasKey(p => p.Id); 

        builder.Property(p => p.Name)
            .IsRequired() 
            .HasMaxLength(200);

        builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(p => p.StartDate)
            .IsRequired(); 

        builder.Property(p => p.EndDate)
            .IsRequired(false); 

        builder.Property(p => p.Status)
            .IsRequired() 
            .HasMaxLength(50); 


    }
}
