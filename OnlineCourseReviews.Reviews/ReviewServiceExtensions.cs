using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OnlineCourseReviews.Reviews;

public static class ReviewServiceExtensions
{
    public static IServiceCollection AddReviewServices(this IServiceCollection services,
        ConfigurationManager config)
    {
        string? connectionString = config.GetConnectionString("ReviewsConnectionString");
        services.AddDbContext<ReviewDbContext>(options => options.UseSqlServer(connectionString));
        services.AddScoped<IReviewService, ReviewService>();
        services.AddScoped<IReviewRepository, EfReviewRepository>();
        
        return services;
    }
}