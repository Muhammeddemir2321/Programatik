using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planora.Domain.Entities;

namespace Planora.Persistence.Configurations;

public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).ValueGeneratedOnAdd();
        builder.Property(t => t.FullName).IsRequired().HasMaxLength(100);

        builder.HasOne(t => t.School)
               .WithMany(s => s.Teachers)
               .HasForeignKey(t => t.SchoolId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(t => t.Lecture)
               .WithMany(l => l.Teachers)
               .HasForeignKey(t => t.LectureId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
