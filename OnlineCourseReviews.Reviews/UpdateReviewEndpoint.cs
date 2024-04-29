using FastEndpoints;

namespace OnlineCourseReviews.Reviews;

internal class UpdateReviewEndpoint(IReviewService reviewService) : Endpoint<UpdateReviewRequest, ReviewDto>
{
    public override void Configure()
    {
        Put("/api/reviews/{Id}");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(UpdateReviewRequest request, CancellationToken cancellationToken)
    {
        var review = await reviewService.GetReviewByIdAsync(request.Id);
        
        if (review is null)
        {
            await SendNotFoundAsync(cancellation: cancellationToken);
            return;
        }
        
        var updatedReview = new ReviewDto(review.Id,
            request.CourseId,
            request.UserId,
            null,
            request.ReviewText,
            request.Rating,
            request.IsRecommended,
            request.IsCourseCompleted,
            request.PricePaid,
            request.DiscountCodeUsed);
        
        updatedReview = await reviewService.UpdateReviewAsync(updatedReview);
        await SendOkAsync(updatedReview, cancellation: cancellationToken);
    }
}