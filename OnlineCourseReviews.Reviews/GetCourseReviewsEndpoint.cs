using FastEndpoints;

namespace OnlineCourseReviews.Reviews;

internal class GetCourseReviewsEndpoint(IReviewService reviewService) : EndpointWithoutRequest<GetCourseReviewsResponse>
{
    public override void Configure()
    {
        Get("/api/reviews");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var reviews = await reviewService.GetCourseReviewsAsync();
        await SendAsync(new GetCourseReviewsResponse
        {
            Reviews = reviews
        }, cancellation: cancellationToken);
    }
}