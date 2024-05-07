using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineCourseReviews.Courses.Data;
using Serilog;

namespace OnlineCourseReviews.Courses.Services;

public static class CourseServiceExtensions
{
    public static IServiceCollection AddCourseServices(this IServiceCollection services,
        ConfigurationManager config, ILogger logger)
    {
        string? connectionString = config.GetConnectionString("CoursesConnectionString");
        services.AddDbContext<CoursesDbContext>(options => options.UseSqlServer(connectionString));
        // services.AddScoped<IReviewService, ReviewService>();
        // services.AddScoped<IReviewRepository, EfReviewRepository>();
        
        logger.Information("Registered {Module} services", "Reviews");
        
        return services;
    }
}