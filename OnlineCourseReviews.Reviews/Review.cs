using Ardalis.GuardClauses;

namespace OnlineCourseReviews.Reviews;

internal class Review
{
    public Guid Id { get; private set; }

    public Guid CourseId { get; private set; }
    
    public string UserId { get; private set; }
    
    public string ReviewText { get; private set; }
    
    public int Rating { get; private set; }
    
    public bool IsRecommended { get; private set; }
    
    public bool IsCourseCompleted { get; private set; }
    
    public decimal? PricePaid { get; private set; }
    
    public string? DiscountCodeUsed { get; private set; }
    
    public DateTime CreatedAt { get; private set; }
    
    public bool IsVisible { get; private set; }
    
    public Guid ApprovedByUserId { get; private set; }

    internal Review(Guid courseId, string userId, string reviewText, int rating, bool isRecommended, 
        bool isCourseCompleted, decimal? pricePaid, string? discountCodeUsed)
    {
        Id = Guid.NewGuid();
        CourseId = Guard.Against.Default(courseId);
        UserId = Guard.Against.NullOrEmpty(userId);
        ReviewText = Guard.Against.NullOrEmpty(reviewText);
        Rating = Guard.Against.NegativeOrZero(rating);
        IsRecommended = isRecommended;
        IsCourseCompleted = isCourseCompleted;
        PricePaid = pricePaid.HasValue ? Guard.Against.NegativeOrZero(pricePaid.Value) : null;
        DiscountCodeUsed = discountCodeUsed;
        CreatedAt = DateTime.UtcNow;
    }
    
    internal void ApproveReview(Guid approvedByUserId)
    {
        IsVisible = true;
        ApprovedByUserId = Guard.Against.Default(approvedByUserId);
    }
}