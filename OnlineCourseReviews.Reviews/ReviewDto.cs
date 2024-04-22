namespace OnlineCourseReviews.Reviews;

public record ReviewDto(Guid Id, string CourseName, string Review, int Rating, bool IsRecommended, DateTime CreatedAt);