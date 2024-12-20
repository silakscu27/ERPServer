using ERPServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERPServer.Infrastructure.Configurations
{
    public sealed class QualityReportConfiguration : IEntityTypeConfiguration<QualityReport>
    {
        public void Configure(EntityTypeBuilder<QualityReport> builder)
        {
            builder.ToTable("QualityReports"); 

            builder.HasKey(q => q.Id); 

            builder.Property(q => q.Name)
                .IsRequired() 
                .HasMaxLength(100); 

            builder.Property(q => q.CreatedDate)
                .IsRequired() 
                .HasColumnType("datetime"); 

            builder.Property(q => q.Description)
                .HasMaxLength(500); 
        }
    }
}
