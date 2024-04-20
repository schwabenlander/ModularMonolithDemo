namespace OnlineCourseReviews.Reviews;

public record CourseReviewDto(Guid Id, string CourseName, string Review, int Rating, bool IsRecommended, DateTime CreatedAt);