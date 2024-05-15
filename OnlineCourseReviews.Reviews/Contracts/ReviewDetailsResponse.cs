namespace OnlineCourseReviews.Reviews.Contracts;

public record ReviewDetailsResponse(
    Guid ReviewId,
    Guid CourseId,
    string UserId,
    string ReviewText,
    int Rating,
    bool IsRecommended,
    bool IsCourseCompleted,
    decimal? PricePaid,
    string? DiscountCodeUsed);