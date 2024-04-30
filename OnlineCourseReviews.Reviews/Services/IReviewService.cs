using OnlineCourseReviews.Reviews.Dtos;

namespace OnlineCourseReviews.Reviews.Services;

internal interface IReviewService
{
    Task<List<ReviewDto>> GetReviewsAsync();
    
    Task<ReviewDto?> GetReviewByIdAsync(Guid reviewId);
    
    Task<ReviewDto> AddReviewAsync(ReviewDto reviewDto);
    
    Task<ReviewDto> UpdateReviewAsync(ReviewDto reviewDto);
    
    Task DeleteReviewAsync(Guid reviewId);
    
    Task<bool> ReviewExistsAsync(Guid reviewId);
}