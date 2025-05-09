using Core.Utilities.IoC;
using Microsoft.EntityFrameworkCore;
using Planora.Domain.Entities;

namespace Planora.Persistence.Contexts;

public class PlanoraDbContext : DbContext
{
    public PlanoraDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
    {
        ServiceTool.SetDbContextOptions(dbContextOptions);
    }
    public DbSet<School> Schools { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<ClassCourseAssignment>  ClassCourseAssignments{ get; set; }
    public DbSet<Grade> Grades { get; set; }
    public DbSet<Lecture> Lectures { get; set; }
    public DbSet<ClassSection> ClassSections { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PlanoraDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

}