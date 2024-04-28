using Microsoft.EntityFrameworkCore;

namespace OnlineCourseReviews.Reviews;

internal class EfReviewRepository(ReviewDbContext dbContext) : IReviewRepository
{
    public async Task<List<Review>> GetAllAsync()
    {
        return await dbContext.Reviews.ToListAsync();
    }

    public async Task<Review?> GetByIdAsync(Guid reviewId)
    {
        return await dbContext.Reviews.FindAsync(reviewId);
    }

    public async Task AddAsync(Review review)
    {
        await dbContext.AddAsync(review);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Review review)
    {
        dbContext.Update(review);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Review review)
    {
        dbContext.Remove(review);
        await dbContext.SaveChangesAsync();
    }
}