namespace OnlineCourseReviews.Reviews;

internal class ReviewService(IReviewRepository reviewRepository) : IReviewService
{
    public async Task<List<ReviewDto>> GetReviewsAsync()
    {
        var reviews = (await reviewRepository.GetAllAsync())
            .Select(r => new ReviewDto(r.Id, r.CourseId.ToString(), r.ReviewText, r.Rating, r.IsRecommended, r.CreatedAt))
            .ToList();

        return reviews;
    }
}