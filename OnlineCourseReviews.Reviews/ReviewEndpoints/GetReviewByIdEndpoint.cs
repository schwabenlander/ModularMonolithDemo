using FastEndpoints;
using OnlineCourseReviews.Reviews.Dtos;
using OnlineCourseReviews.Reviews.Services;

namespace OnlineCourseReviews.Reviews.ReviewEndpoints;

internal class GetReviewByIdEndpoint(IReviewService reviewService) : Endpoint<GetReviewByIdRequest, ReviewDto>
{
    public override void Configure()
    {
        Get("/api/reviews/{Id}");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(GetReviewByIdRequest request, CancellationToken cancellationToken)
    {
        var review = await reviewService.GetReviewByIdAsync(request.Id);
        
        if (review is null)
        {
            await SendNotFoundAsync(cancellationToken);
            return;
        }
        
        await SendAsync(review, cancellation:cancellationToken);
    }
}

internal record GetReviewByIdRequest(Guid Id);
