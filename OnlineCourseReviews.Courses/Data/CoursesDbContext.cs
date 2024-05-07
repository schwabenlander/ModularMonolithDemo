using System.Reflection;
using Microsoft.EntityFrameworkCore;
using OnlineCourseReviews.Courses.Models;

namespace OnlineCourseReviews.Courses.Data;

public class CoursesDbContext : DbContext
{
    internal DbSet<Course> Courses { get; set; }
    
    public CoursesDbContext(DbContextOptions<CoursesDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Courses");
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<decimal>().HavePrecision(18, 6);
    }
}