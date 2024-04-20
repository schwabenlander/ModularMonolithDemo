namespace OnlineCourseReviews.Reviews;

public class GetCourseReviewsResponse
{
    public List<CourseReviewDto> Reviews { get; set; } = new();
}