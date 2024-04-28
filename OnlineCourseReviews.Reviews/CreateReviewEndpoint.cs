using FastEndpoints;

namespace OnlineCourseReviews.Reviews;

internal class CreateReviewEndpoint(IReviewService reviewService) : Endpoint<CreateReviewRequest, ReviewDto>
{
    public override void Configure()
    {
        Post("/api/reviews");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(CreateReviewRequest request, CancellationToken cancellationToken)
    {
        var review = new ReviewDto(null,
            request.CourseId,
            request.UserId,
            null,
            request.ReviewText,
            request.Rating,
            request.IsRecommended,
            request.IsCourseCompleted,
            request.PricePaid,
            request.DiscountCodeUsed);
        
        await reviewService.AddReviewAsync(review);
        await SendCreatedAtAsync<GetReviewByIdEndpoint>(new { Id = review.Id }, 
            review, cancellation: cancellationToken);
    }
}