using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planora.Domain.Entities;

namespace Planora.Persistence.EntityConfigurations;

public class SchoolScheduleSettingConfiguration : IEntityTypeConfiguration<SchoolScheduleSetting>
{
    public void Configure(EntityTypeBuilder<SchoolScheduleSetting> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.FirstLessonStartTime).IsRequired();
        builder.Property(x => x.LessonDurationMinutes).IsRequired();
        builder.Property(x => x.BreakDurationMinutes).IsRequired();
        builder.Property(x => x.DailyLessonCount).IsRequired();

        builder.HasOne(x => x.School)
        .WithOne()
        .HasForeignKey<SchoolScheduleSetting>(x => x.SchoolId)
        .OnDelete(DeleteBehavior.Cascade);
    }
}
