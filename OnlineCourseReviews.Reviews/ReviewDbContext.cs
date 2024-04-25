using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace OnlineCourseReviews.Reviews;

public class ReviewDbContext : DbContext
{
    internal DbSet<Review> Reviews { get; set; }

    public ReviewDbContext(DbContextOptions options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Reviews");
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<decimal>().HavePrecision(18, 6);
    }
}