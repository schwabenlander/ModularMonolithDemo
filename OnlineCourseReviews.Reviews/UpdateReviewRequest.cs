namespace OnlineCourseReviews.Reviews;

internal class UpdateReviewRequest
{
    public required Guid Id { get; set; }
    
    public required Guid CourseId { get; set; }
    
    public required string UserId { get; set; }
    
    public required string ReviewText { get; set; }
    
    public required int Rating { get; set; }
    
    public bool IsRecommended { get; set; }
    
    public bool IsCourseCompleted { get; set; }
    
    public decimal? PricePaid { get; set; }
    
    public string? DiscountCodeUsed { get; set; }
}