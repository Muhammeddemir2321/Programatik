using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planora.Domain.Entities;

namespace Planora.Persistence.Configurations;

public class ClassSectionConfiguration : IEntityTypeConfiguration<ClassSection>
{
    public void Configure(EntityTypeBuilder<ClassSection> builder)
    {
        builder.HasKey(cs => cs.Id);
        builder.Property(cs => cs.Id).ValueGeneratedOnAdd();
        builder.Property(cs => cs.Name).IsRequired().HasMaxLength(100);

        builder.HasOne(cs => cs.School)
               .WithMany(s => s.ClassSections)
               .HasForeignKey(cs => cs.SchoolId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(cs => cs.Grade)
               .WithMany(g => g.ClassSections)
               .HasForeignKey(cs => cs.GradeId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
