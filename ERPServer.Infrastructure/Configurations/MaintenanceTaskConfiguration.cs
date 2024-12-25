using ERPServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERPServer.Infrastructure.Configurations
{
    public sealed class MaintenanceTaskConfiguration : IEntityTypeConfiguration<MaintenanceTask>
    {
        public void Configure(EntityTypeBuilder<MaintenanceTask> builder)
        {
            builder.ToTable("MaintenanceTasks");

            builder.HasKey(mt => mt.Id);

            builder.Property(mt => mt.TaskName)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(mt => mt.Status)
                   .HasMaxLength(50);

            builder.Property(mt => mt.ScheduledDate)
                   .IsRequired();

            builder.HasOne(mt => mt.Equipment)
                   .WithMany(e => e.MaintenanceTasks)
                   .HasForeignKey(mt => mt.EquipmentId)
                   .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
