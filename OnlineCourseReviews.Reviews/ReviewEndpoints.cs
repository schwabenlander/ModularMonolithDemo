using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace OnlineCourseReviews.Reviews;

public static class ReviewEndpoints
{
    public static void MapReviewEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints
            .MapGet("/api/reviews", async (IReviewService reviewService) => await reviewService.GetCourseReviewsAsync())
            .WithName("GetCourseReviews");
    }
}

public static class ReviewServiceExtensions
{
    public static IServiceCollection AddReviewServices(this IServiceCollection services)
    {
        services.AddScoped<IReviewService, ReviewService>();
        return services;
    }
}