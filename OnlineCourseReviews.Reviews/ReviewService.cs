namespace OnlineCourseReviews.Reviews;

internal class ReviewService(IReviewRepository reviewRepository) : IReviewService
{
    public async Task<List<ReviewDto>> GetReviewsAsync()
    {
        var reviews = (await reviewRepository.GetAllAsync())
            .Select(r => new ReviewDto(r.Id,
                r.CourseId.ToString(),
                r.ReviewText,
                r.Rating,
                r.IsRecommended,
                r.CreatedAt))
            .ToList();

        return reviews;
    }

    public async Task<ReviewDto> GetReviewByIdAsync(Guid reviewId)
    {
        var review = await reviewRepository.GetByIdAsync(reviewId);
        var reviewDto = new ReviewDto(review.Id,
            review.CourseId.ToString(),
            review.ReviewText,
            review.Rating,
            review.IsRecommended,
            review.CreatedAt);
        
        return reviewDto;
    }

    public async Task AddReviewAsync(Guid courseId, string userId, string reviewText, int rating, bool isRecommended,
        bool isCourseCompleted, decimal? pricePaid, string? discountCodeUsed)
    {
        var review = new Review(courseId,
            userId,
            reviewText,
            rating,
            isRecommended,
            isCourseCompleted,
            pricePaid,
            discountCodeUsed);
        
        await reviewRepository.AddAsync(review);
    }

    public async Task UpdateReviewAsync(Guid reviewId, string reviewText, int rating, bool isRecommended, 
        bool isCourseCompleted, decimal? pricePaid, string? discountCodeUsed)
    {
        var review = await reviewRepository.GetByIdAsync(reviewId);
        review.Update(reviewText, rating, isRecommended, isCourseCompleted, pricePaid, discountCodeUsed);
        
        await reviewRepository.SaveChangesAsync(review);
    }

    public async Task DeleteReviewAsync(Guid reviewId)
    {
        var review = await reviewRepository.GetByIdAsync(reviewId);
        
        await reviewRepository.DeleteAsync(review);
    }
}