namespace OnlineCourseReviews.Reviews;

internal interface IReviewRepository : IReadOnlyReviewRepository
{
    Task AddAsync(Review review);
    
    Task UpdateAsync(Review review);
    
    Task DeleteAsync(Review review);
}

internal interface IReadOnlyReviewRepository
{
    Task<List<Review>> GetAllAsync();
    
    Task<Review?> GetByIdAsync(Guid reviewId);
}