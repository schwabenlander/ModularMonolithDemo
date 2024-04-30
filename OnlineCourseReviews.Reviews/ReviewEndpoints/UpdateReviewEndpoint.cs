using FastEndpoints;
using OnlineCourseReviews.Reviews.Dtos;
using OnlineCourseReviews.Reviews.Services;

namespace OnlineCourseReviews.Reviews.ReviewEndpoints;

internal class UpdateReviewEndpoint(IReviewService reviewService) : Endpoint<UpdateReviewRequest, ReviewDto>
{
    public override void Configure()
    {
        Put("/api/reviews/{Id}");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(UpdateReviewRequest request, CancellationToken cancellationToken)
    {
        if (!await reviewService.ReviewExistsAsync(request.Id))
        {
            await SendNotFoundAsync(cancellation: cancellationToken);
            return;
        }
        
        var updatedReview = new ReviewDto(
            request.Id,
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

internal class UpdateReviewRequest
{
    public required Guid Id { get; set; }
    
    public required Guid CourseId { get; set; }
    
    public required string UserId { get; set; }
    
    public required string ReviewText { get; set; }
    
    public required int Rating { get; set; }
    
    public bool IsRecommended { get; set; }
    
    public bool IsCourseCompleted { get; set; }
    
    public decimal? PricePaid { get; set; }
    
    public string? DiscountCodeUsed { get; set; }
}