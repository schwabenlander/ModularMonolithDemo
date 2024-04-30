using FastEndpoints;
using OnlineCourseReviews.Reviews.Dtos;
using OnlineCourseReviews.Reviews.Services;

namespace OnlineCourseReviews.Reviews.ReviewEndpoints;

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
        
        review = await reviewService.AddReviewAsync(review);
        await SendCreatedAtAsync<GetReviewByIdEndpoint>(new { Id = review.Id }, 
            review, cancellation: cancellationToken);
    }
}

internal class CreateReviewRequest
{
    public required Guid CourseId { get; set; }
    
    public required string UserId { get; set; }
    
    public required string ReviewText { get; set; }
    
    public required int Rating { get; set; }
    
    public bool IsRecommended { get; set; }
    
    public bool IsCourseCompleted { get; set; }
    
    public decimal? PricePaid { get; set; }
    
    public string? DiscountCodeUsed { get; set; }
}