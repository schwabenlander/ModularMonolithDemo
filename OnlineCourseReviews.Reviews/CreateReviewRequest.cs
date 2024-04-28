namespace OnlineCourseReviews.Reviews;

internal class CreateReviewRequest
{
    public required Guid CourseId { get; set; }
    
    public required string UserId { get; set; }
    
    public required string ReviewText { get; set; }
    
    public required int Rating { get; set; }
    
    public bool IsRecommended { get; set; }
    
    public bool IsCourseCompleted { get; set; }
    
    public decimal? PricePaid { get; set; }
    
    public string? DiscountCodeUsed { get; set; }
}