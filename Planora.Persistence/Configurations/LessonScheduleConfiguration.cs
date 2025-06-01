using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planora.Domain.Entities;

namespace Planora.Persistence.Configurations;

public class LessonScheduleConfiguration : IEntityTypeConfiguration<LessonSchedule>
{
    public void Configure(EntityTypeBuilder<LessonSchedule> builder)
    {
        builder.HasKey(cc => cc.Id);
        builder.Property(cc => cc.Id).ValueGeneratedOnAdd();
        builder.Property(cc => cc.DayOfWeek).IsRequired();
        builder.Property(cc => cc.LessonIndex).IsRequired();

        builder.HasOne(c => c.School)
               .WithMany(s => s.LessonSchedules)
               .HasForeignKey(c => c.SchoolId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.Lecture)
               .WithMany(l => l.LessonSchedules)
               .HasForeignKey(c => c.LectureId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.Teacher)
               .WithMany(l => l.LessonSchedules)
               .HasForeignKey(c => c.TeacherId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.ClassSection)
               .WithMany(l => l.LessonSchedules)
               .HasForeignKey(c => c.ClassSectionId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
