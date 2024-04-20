namespace OnlineCourseReviews.Reviews;

internal interface IReviewService
{
    Task<List<CourseReviewDto>> GetCourseReviewsAsync();
}