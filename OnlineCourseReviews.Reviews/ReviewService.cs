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
            return null;
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

    public async Task<ReviewDto> AddReviewAsync(ReviewDto reviewDto)
    {
        // TODO: Add validation for reviewDto properties
        
        var review = new Review(
            reviewDto.Id ?? Guid.NewGuid(),
            reviewDto.CourseId,
            reviewDto.UserId,
            reviewDto.ReviewText,
            reviewDto.Rating,
            reviewDto.IsRecommended,
            reviewDto.IsCourseCompleted,
            reviewDto.PricePaid,
            reviewDto.DiscountCodeUsed);
        
        var addedReview = await reviewRepository.AddAsync(review);

        return addedReview.ToDto();
    }

    public async Task<ReviewDto> UpdateReviewAsync(ReviewDto reviewDto)
    {
        // TODO: Add validation for reviewDto properties
        
        if (reviewDto.Id is null)
        {
            throw new ArgumentNullException(nameof(reviewDto.Id));
        }
        
        var review = await reviewRepository.GetByIdAsync(reviewDto.Id.Value);
        
        if (review is null)
        {
            throw new NotFoundException(reviewDto.Id.ToString()!, nameof(reviewDto));
        }
        
        review.Update(
            reviewDto.ReviewText, 
            reviewDto.Rating, 
            reviewDto.IsRecommended, 
            reviewDto.IsCourseCompleted,
            reviewDto.PricePaid, 
            reviewDto.DiscountCodeUsed);
        
        var updatedReview = await reviewRepository.UpdateAsync(review);

        return updatedReview.ToDto();
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

    public async Task<bool> ReviewExistsAsync(Guid reviewId)
    {
        var review = await reviewRepository.GetByIdAsync(reviewId);
        return review is not null;
    }
}