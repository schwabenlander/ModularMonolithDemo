namespace OnlineCourseReviews.Reviews;

internal interface IReviewService
{
    Task<List<ReviewDto>> GetReviewsAsync();
    
    Task<ReviewDto?> GetReviewByIdAsync(Guid reviewId);
    
    Task AddReviewAsync(ReviewDto reviewDto);
    
    Task UpdateReviewAsync(ReviewDto reviewDto);
    
    Task DeleteReviewAsync(Guid reviewId);
}