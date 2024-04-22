namespace OnlineCourseReviews.Reviews;

internal interface IReviewService
{
    Task<List<ReviewDto>> GetReviewsAsync();
}