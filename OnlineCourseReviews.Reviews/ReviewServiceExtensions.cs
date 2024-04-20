using Microsoft.Extensions.DependencyInjection;

namespace OnlineCourseReviews.Reviews;

public static class ReviewServiceExtensions
{
    public static IServiceCollection AddReviewServices(this IServiceCollection services)
    {
        services.AddScoped<IReviewService, ReviewService>();
        return services;
    }
}