using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planora.Domain.Entities;

namespace Planora.Persistence.Configurations;

public class ClassTeachingAssignmentConfiguration : IEntityTypeConfiguration<ClassTeachingAssignment>
{
    public void Configure(EntityTypeBuilder<ClassTeachingAssignment> builder)
    {

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();
        builder.Property(c => c.WeeklyHourCount).IsRequired();

        builder.HasOne(c => c.School)
               .WithMany(s => s.ClassTeachingAssignments)
               .HasForeignKey(c => c.SchoolId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.Lecture)
               .WithMany(l => l.ClassTeachingAssignments)
               .HasForeignKey(c => c.LectureId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.Teacher)
               .WithMany(l => l.ClassTeachingAssignments)
               .HasForeignKey(c => c.TeacherId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.ClassSection)
               .WithMany(l => l.ClassTeachingAssignments)
               .HasForeignKey(c => c.ClassSectionId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
