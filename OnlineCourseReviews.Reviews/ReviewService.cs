using Ardalis.GuardClauses;

namespace OnlineCourseReviews.Reviews;

internal class ReviewService(IReviewRepository reviewRepository) : IReviewService
{
    public async Task<List<ReviewDto>> GetReviewsAsync()
    {
        var reviews = await reviewRepository.GetAllAsync();
        var reviewDtos = reviews.Select(review => new ReviewDto(review.Id,
            review.CourseId,
            review.UserId,
            review.CourseId.ToString(),
            review.ReviewText,
            review.Rating,
            review.IsRecommended,
            review.IsCourseCompleted,
            review.PricePaid,
            review.DiscountCodeUsed)).ToList();
        
        return reviewDtos;
    }

    public async Task<ReviewDto?> GetReviewByIdAsync(Guid reviewId)
    {
        var review = await reviewRepository.GetByIdAsync(reviewId);
        
        if (review is null)
        {
            throw new NotFoundException(reviewId.ToString(), nameof(review));
        }
        
        var reviewDto = new ReviewDto(reviewId,
            review.CourseId,
            review.UserId,
            review.CourseId.ToString(),
            review.ReviewText,
            review.Rating,
            review.IsRecommended,
            review.IsCourseCompleted,
            review.PricePaid,
            review.DiscountCodeUsed);
        
        return reviewDto;
    }

    public async Task AddReviewAsync(ReviewDto reviewDto)
    {
        // TODO: Add validation for reviewDto properties
        
        var review = new Review(reviewDto.CourseId,
            reviewDto.UserId,
            reviewDto.ReviewText,
            reviewDto.Rating,
            reviewDto.IsRecommended,
            reviewDto.IsCourseCompleted,
            reviewDto.PricePaid,
            reviewDto.DiscountCodeUsed);
        
        await reviewRepository.AddAsync(review);
    }

    public async Task UpdateReviewAsync(ReviewDto reviewDto)
    {
        // TODO: Add validation for reviewDto properties
        
        if (reviewDto.Id is null)
        {
            throw new ArgumentNullException(nameof(reviewDto.Id));
        }
        
        var review = await reviewRepository.GetByIdAsync(reviewDto.Id.Value);
        
        if (review is null)
        {
            throw new NotFoundException(reviewDto.Id.ToString(), nameof(reviewDto));
        }
        
        review.Update(reviewDto.ReviewText, reviewDto.Rating, reviewDto.IsRecommended, reviewDto.IsCourseCompleted,
            reviewDto.PricePaid, reviewDto.DiscountCodeUsed);
        
        await reviewRepository.SaveChangesAsync(review);
    }

    public async Task DeleteReviewAsync(Guid reviewId)
    {
        var review = await reviewRepository.GetByIdAsync(reviewId);

        if (review is null)
        {
            throw new NotFoundException(reviewId.ToString(), nameof(review));
        }
        
        await reviewRepository.DeleteAsync(review);
    }
}