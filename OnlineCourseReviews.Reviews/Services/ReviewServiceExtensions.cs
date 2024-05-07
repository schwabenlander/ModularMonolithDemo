using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineCourseReviews.Reviews.Data;
using OnlineCourseReviews.Reviews.Repositories;
using Serilog;

namespace OnlineCourseReviews.Reviews.Services;

public static class ReviewServiceExtensions
{
    public static IServiceCollection AddReviewServices(this IServiceCollection services,
        ConfigurationManager config, ILogger logger)
    {
        string? connectionString = config.GetConnectionString("ReviewsConnectionString");
        services.AddDbContext<ReviewsDbContext>(options => options.UseSqlServer(connectionString));
        services.AddScoped<IReviewService, ReviewService>();
        services.AddScoped<IReviewRepository, EfReviewRepository>();
        
        logger.Information("Registered {Module} services", "Reviews");
        
        return services;
    }
}