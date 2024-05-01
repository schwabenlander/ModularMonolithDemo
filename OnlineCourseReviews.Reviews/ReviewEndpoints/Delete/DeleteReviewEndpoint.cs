using FastEndpoints;
using OnlineCourseReviews.Reviews.Services;

namespace OnlineCourseReviews.Reviews.ReviewEndpoints.Delete;

internal class DeleteReviewEndpoint(IReviewService reviewService) : Endpoint<DeleteReviewRequest>
{
    public override void Configure()
    {
        Delete("/api/reviews/{Id}");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(DeleteReviewRequest request, CancellationToken cancellationToken)
    {
        if (!await reviewService.ReviewExistsAsync(request.Id))
        {
            await SendNotFoundAsync(cancellation: cancellationToken);
            return;
        }
        
        await reviewService.DeleteReviewAsync(request.Id);
        await SendNoContentAsync(cancellation: cancellationToken);
    }
}