using MediatR;
using OnlineCourseReviews.Reviews.Services;

namespace OnlineCourseReviews.Reviews.Contracts;

public record ReviewDetailsQuery(Guid ReviewId) : IRequest<ReviewDetailsResponse>;

public class ReviewDetailsQueryHandler(IReviewService reviewService) : IRequestHandler<ReviewDetailsQuery, ReviewDetailsResponse>
{
    public async Task<ReviewDetailsResponse> Handle(ReviewDetailsQuery request, CancellationToken cancellationToken)
    {
        var review = await reviewService.GetReviewByIdAsync(request.ReviewId);
        
        if (review is null)
        {
            return null;
        }

        var response = new ReviewDetailsResponse(review.Id!.Value,
            review.CourseId,
            review.UserId,
            review.ReviewText,
            review.Rating,
            review.IsRecommended,
            review.IsCourseCompleted,
            review.PricePaid,
            review.DiscountCodeUsed);
        
        return response;
    }
}