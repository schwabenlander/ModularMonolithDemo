using Ardalis.GuardClauses;
using OnlineCourseReviews.Courses.Dtos;
using OnlineCourseReviews.Reviews.Models;

namespace OnlineCourseReviews.Courses.Models;

public class Course
{
    public Guid Id { get; private set; }
    
    public Guid SchoolId { get; private set; }
    
    public string Title { get; private set; }
    
    public string Description { get; private set; }
    
    public string Instructor { get; private set; }
    
    public decimal Price { get; private set; }
    
    public string Url { get; private set; }
    
    private readonly List<Review> _reviews = [];
    public IReadOnlyCollection<Review> Reviews => _reviews.AsReadOnly();

    public bool IsVisible { get; private set; }
    
    public DateTime CreatedAt { get; private set; }
    
    public Course(Guid id, Guid schoolId, string title, string description, string instructor, decimal price, string url)
    {
        Id = Guard.Against.Default(id);
        SchoolId = Guard.Against.Default(schoolId);
        Title = Guard.Against.NullOrEmpty(title);
        Description = Guard.Against.NullOrEmpty(description);
        Instructor = Guard.Against.NullOrEmpty(instructor);
        Price = Guard.Against.Negative(price);
        Url = Guard.Against.NullOrEmpty(url);
        CreatedAt = DateTime.UtcNow;
    }
    
    public void ShowCourse() => IsVisible = true;
    
    public void HideCourse() => IsVisible = false;
    
    public void AddReviewToCourse(Review review)
    {
        Guard.Against.Null(review);
        
        var reviewExists = _reviews.Any(r => r.Id == review.Id);
        if (reviewExists)
        {
            throw new InvalidOperationException("Review already exists for this course.");
        }
        
        _reviews.Add(review);
    }
    
    public void Update(Guid schoolId, string title, string description, string instructor, decimal price, string url)
    {
        SchoolId = Guard.Against.Default(schoolId);
        Title = Guard.Against.NullOrEmpty(title);
        Description = Guard.Against.NullOrEmpty(description);
        Instructor = Guard.Against.NullOrEmpty(instructor);
        Price = Guard.Against.Negative(price);
        Url = Guard.Against.NullOrEmpty(url);
    }
    
    public CourseDto ToDto() =>
        new CourseDto(Id,
            SchoolId,
            Title,
            Description,
            Instructor,
            Price,
            Url);
}