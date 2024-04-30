using Microsoft.EntityFrameworkCore;
using OnlineCourseReviews.Reviews.Data;
using OnlineCourseReviews.Reviews.Models;

namespace OnlineCourseReviews.Reviews.Repositories;

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

    public async Task<Review> AddAsync(Review review)
    {
        var reviewEntity = await dbContext.AddAsync(review);
        await dbContext.SaveChangesAsync();
        
        return reviewEntity.Entity;
    }

    public async Task<Review> UpdateAsync(Review review)
    {
        var reviewEntity = dbContext.Update(review);
        await dbContext.SaveChangesAsync();
        
        return reviewEntity.Entity;
    }

    public async Task DeleteAsync(Review review)
    {
        dbContext.Remove(review);
        await dbContext.SaveChangesAsync();
    }
}