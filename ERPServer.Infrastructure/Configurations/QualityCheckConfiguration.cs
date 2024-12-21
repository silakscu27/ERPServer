using ERPServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERPServer.Infrastructure.Configurations
{
    public sealed class QualityCheckConfiguration : IEntityTypeConfiguration<QualityCheck>
    {
        public void Configure(EntityTypeBuilder<QualityCheck> builder)
        {
            builder.ToTable("QualityChecks");

            // Primary Key
            builder.HasKey(qc => qc.Id);

            // Properties
            builder.Property(qc => qc.CheckDate)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(qc => qc.Checkpoint)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(qc => qc.Result)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(qc => qc.ReportId)
                .IsRequired();

            // Relationships
            builder.HasOne(qc => qc.QualityReport)
                   .WithMany(qr => qr.QualityChecks)
                   .HasForeignKey(qc => qc.ReportId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
