using FastEndpoints;
using OnlineCourseReviews.Reviews.Services;

namespace OnlineCourseReviews.Reviews.ReviewEndpoints.Get;

public class GetReviewsEndpoint(IReviewService reviewService) : EndpointWithoutRequest<GetReviewsResponse>
{
    public override void Configure()
    {
        Get("/api/reviews");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var reviews = await reviewService.GetReviewsAsync();
        await SendAsync(new GetReviewsResponse
        {
            Reviews = reviews
        }, cancellation: cancellationToken);
    }
}