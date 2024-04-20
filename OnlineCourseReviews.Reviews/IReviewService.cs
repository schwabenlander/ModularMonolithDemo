namespace OnlineCourseReviews.Reviews;

internal interface IReviewService
{
    Task<IEnumerable<CourseReviewDto>> GetCourseReviewsAsync();
}