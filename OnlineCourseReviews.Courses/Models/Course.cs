using Ardalis.GuardClauses;
using OnlineCourseReviews.Courses.Dtos;

namespace OnlineCourseReviews.Courses.Models;

internal class Course
{
    public Guid Id { get; private set; }
    
    public Guid SchoolId { get; private set; }
    
    public string Title { get; private set; }
    
    public string Description { get; private set; }
    
    public string Instructor { get; private set; }
    
    public decimal Price { get; private set; }
    
    public string Url { get; private set; }

    public bool IsVisible { get; private set; }
    
    public DateTime CreatedAt { get; private set; }
    
    internal Course(Guid id, Guid schoolId, string title, string description, string instructor, decimal price, string url)
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
    
    internal void ShowCourse() => IsVisible = true;
    
    internal void HideCourse() => IsVisible = false;
    
    internal void Update(string title, string description, string instructor, decimal price, string url)
    {
        Title = Guard.Against.NullOrEmpty(title);
        Description = Guard.Against.NullOrEmpty(description);
        Instructor = Guard.Against.NullOrEmpty(instructor);
        Price = Guard.Against.Negative(price);
        Url = Guard.Against.NullOrEmpty(url);
    }
    
    internal CourseDto ToDto() =>
        new CourseDto(Id,
            SchoolId,
            Title,
            Description,
            Instructor,
            Price,
            Url);
}