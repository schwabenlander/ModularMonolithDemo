namespace OnlineCourseReviews.Reviews;

internal interface IReviewRepository : IReadOnlyReviewRepository
{
    Task<Review> AddAsync(Review review);
    
    Task<Review> UpdateAsync(Review review);
    
    Task DeleteAsync(Review review);
}

internal interface IReadOnlyReviewRepository
{
    Task<List<Review>> GetAllAsync();
    
    Task<Review?> GetByIdAsync(Guid reviewId);
}