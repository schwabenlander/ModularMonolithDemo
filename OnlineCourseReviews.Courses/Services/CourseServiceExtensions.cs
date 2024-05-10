using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineCourseReviews.Courses.Data;
using OnlineCourseReviews.Courses.Repositories;
using Serilog;

namespace OnlineCourseReviews.Courses.Services;

public static class CourseServiceExtensions
{
    public static IServiceCollection AddCourseServices(this IServiceCollection services,
        ConfigurationManager config, ILogger logger)
    {
        string? connectionString = config.GetConnectionString("CoursesConnectionString");
        services.AddDbContext<CoursesDbContext>(options => options.UseSqlServer(connectionString));
        services.AddScoped<ICourseService, CourseService>();
        services.AddScoped<ICourseRepository, EfCourseRepository>();
        
        logger.Information("Registered {Module} services", "Reviews");
        
        return services;
    }
}