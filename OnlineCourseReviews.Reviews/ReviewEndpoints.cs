using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace OnlineCourseReviews.Reviews;

public static class ReviewEndpoints
{
    public static void MapReviewEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/api/reviews", async (IReviewService reviewService) =>
        {
            return await reviewService.GetCourseReviewsAsync();
        })
        .WithName("GetCourseReviews");
    }
}

internal interface IReviewService
{
    Task<IEnumerable<CourseReviewDto>> GetCourseReviewsAsync();
}

internal class ReviewService : IReviewService
{
    public async Task<IEnumerable<CourseReviewDto>> GetCourseReviewsAsync()
    {
        IEnumerable<CourseReviewDto> reviews = [
            new CourseReviewDto(Guid.NewGuid(), "Getting Started: Modular Monoliths in .NET", "Great course!", 5, true, DateTime.UtcNow),
            new CourseReviewDto(Guid.NewGuid(), "Logging in .NET", "Very informative.", 4, true, DateTime.UtcNow),
            new CourseReviewDto(Guid.NewGuid(), ".NET MAUI", "Boring and overpriced.", 2, false, DateTime.UtcNow),
        ];
        
        return await Task.FromResult(reviews);
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

public record CourseReviewDto(Guid Id, string CourseName, string Review, int Rating, bool IsRecommended, DateTime CreatedAt);
