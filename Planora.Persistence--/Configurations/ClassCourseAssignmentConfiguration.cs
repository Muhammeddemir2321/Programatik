using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planora.Domain.Entities;

namespace Planora.Persistence.Configurations;

public class ClassCourseAssignmentConfiguration : IEntityTypeConfiguration<ClassCourseAssignment>
{
    public void Configure(EntityTypeBuilder<ClassCourseAssignment> builder)
    {
        builder.HasKey(cc => cc.Id);
        builder.Property(cc => cc.Id).ValueGeneratedOnAdd();
        builder.Property(cc=> cc.ScheduleInfo).IsRequired().HasMaxLength(100);

        builder.HasOne(cc=> cc.ClassSection)
               .WithMany(cs => cs.ClassCourseAssignments)
               .HasForeignKey(cc => cc.ClassSectionId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(cc => cc.Course)
               .WithMany(c => c.ClassCourseAssignments)
               .HasForeignKey(cc => cc.CourseId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(cc => cc.Teacher)
               .WithMany(t => t.ClassCourseAssignments)
               .HasForeignKey(cc => cc.TeacherId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
