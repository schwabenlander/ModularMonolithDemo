namespace OnlineCourseReviews.Reviews;

internal class CourseReview
{
    public Guid Id { get; private set; }

    public Guid CourseId { get; private set; }
    
    public Guid UserId { get; private set; }
    
    public string ReviewText { get; private set; }
    
    public int Rating { get; private set; }
    
    public bool IsRecommended { get; private set; }
    
    public bool IsCourseCompleted { get; private set; }
    
    public decimal? PricePaid { get; private set; }
    
    public string? DiscountCodeUsed { get; private set; }
    
    public DateTime CreatedAt { get; private set; }
    
    public bool IsVisible { get; private set; }
    
    public Guid ApprovedByUserId { get; private set; }

    internal CourseReview(Guid courseId, Guid userId, string reviewText, int rating, bool isRecommended, 
        bool isCourseCompleted, decimal? pricePaid, string? discountCodeUsed)
    {
        Id = Guid.NewGuid();
        CourseId = courseId;
        UserId = userId;
        ReviewText = reviewText;
        Rating = rating;
        IsRecommended = isRecommended;
        IsCourseCompleted = isCourseCompleted;
        PricePaid = pricePaid;
        DiscountCodeUsed = discountCodeUsed;
        CreatedAt = DateTime.UtcNow;
    }
    
    internal void ApproveReview(Guid approvedByUserId)
    {
        IsVisible = true;
        ApprovedByUserId = approvedByUserId;
    }
}