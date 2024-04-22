namespace OnlineCourseReviews.Reviews;

internal class ReviewService : IReviewService
{
    public async Task<List<ReviewDto>> GetReviewsAsync()
    {
        List<ReviewDto> reviews = [
            new ReviewDto(Guid.NewGuid(), "Getting Started: Modular Monoliths in .NET", "Great course!", 5, true, DateTime.UtcNow),
            new ReviewDto(Guid.NewGuid(), "Logging in .NET", "Very informative.", 4, true, DateTime.UtcNow),
            new ReviewDto(Guid.NewGuid(), ".NET MAUI", "Boring and overpriced.", 2, false, DateTime.UtcNow),
        ];
        
        return await Task.FromResult(reviews);
    }
}