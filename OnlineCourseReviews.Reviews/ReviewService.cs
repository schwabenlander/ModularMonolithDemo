namespace OnlineCourseReviews.Reviews;

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