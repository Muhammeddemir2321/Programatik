using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planora.Domain.Entities;

namespace Planora.Persistence.Configurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();
        builder.Property(c => c.Name).IsRequired().HasMaxLength(100);

        builder.HasOne(c => c.School)
               .WithMany(s => s.Courses)
               .HasForeignKey(c => c.SchoolId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.Lecture)
               .WithMany(l => l.Courses)
               .HasForeignKey(c => c.LectureId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
