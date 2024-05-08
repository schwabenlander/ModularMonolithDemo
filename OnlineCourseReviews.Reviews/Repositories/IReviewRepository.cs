using OnlineCourseReviews.Reviews.Models;

namespace OnlineCourseReviews.Reviews.Repositories;

public interface IReviewRepository : IReadOnlyReviewRepository
{
    Task<Review> AddAsync(Review review);
    
    Task<Review> UpdateAsync(Review review);
    
    Task DeleteAsync(Review review);
}

public interface IReadOnlyReviewRepository
{
    Task<List<Review>> GetAllAsync();
    
    Task<Review?> GetByIdAsync(Guid reviewId);
}