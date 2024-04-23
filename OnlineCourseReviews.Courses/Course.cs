using Ardalis.GuardClauses;

namespace OnlineCourseReviews.Courses;

internal class Course
{
    public Guid Id { get; private set; }
    
    public Guid? SchoolId { get; private set; }
    
    public string Title { get; private set; }
    
    public string Description { get; private set; }
    
    public string Instructor { get; private set; }
    
    public decimal Price { get; private set; }
    
    public string Url { get; private set; }

    public bool IsVisible { get; private set; }
    
    public DateTime CreatedAt { get; private set; }
    
    internal Course(Guid schoolId, string title, string description, string instructor, decimal price, string url)
    {
        Id = Guid.NewGuid();
        SchoolId = schoolId;
        Title = Guard.Against.NullOrEmpty(title);
        Description = Guard.Against.NullOrEmpty(description);
        Instructor = Guard.Against.NullOrEmpty(instructor);
        Price = Guard.Against.Negative(price);
        Url = Guard.Against.NullOrEmpty(url);
        CreatedAt = DateTime.UtcNow;
    }
    
    internal void PublishCourse() => IsVisible = true;
}