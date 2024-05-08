using System.Reflection;
using Microsoft.EntityFrameworkCore;
using OnlineCourseReviews.Reviews.Models;

namespace OnlineCourseReviews.Reviews.Data;

public class ReviewsDbContext : DbContext
{
    public DbSet<Review> Reviews { get; set; }

    public ReviewsDbContext(DbContextOptions<ReviewsDbContext> options) : base(options)
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