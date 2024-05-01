using OnlineCourseReviews.Reviews.Dtos;

namespace OnlineCourseReviews.Reviews.ReviewEndpoints.Get;

public class GetReviewsResponse
{
    public List<ReviewDto> Reviews { get; set; } = new();
}