namespace OnlineCourseReviews.Reviews.Dtos;

public record ReviewDto(Guid? Id, 
    Guid CourseId,
    string UserId,
    string? CourseName, 
    string ReviewText, 
    int Rating, 
    bool IsRecommended, 
    bool IsCourseCompleted,
    decimal? PricePaid,
    string? DiscountCodeUsed);