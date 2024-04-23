namespace OnlineCourseReviews.Reviews;

internal interface IReviewService
{
    Task<List<ReviewDto>> GetReviewsAsync();
    
    Task<ReviewDto> GetReviewByIdAsync(Guid reviewId);
    
    Task AddReviewAsync(Guid courseId, string userId, string reviewText, int rating, bool isRecommended, 
        bool isCourseCompleted, decimal? pricePaid, string? discountCodeUsed);
    
    Task UpdateReviewAsync(Guid reviewId, string reviewText, int rating, bool isRecommended, 
        bool isCourseCompleted, decimal? pricePaid, string? discountCodeUsed);
    
    Task DeleteReviewAsync(Guid reviewId);
}