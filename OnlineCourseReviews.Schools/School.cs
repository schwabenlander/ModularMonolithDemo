using Ardalis.GuardClauses;

namespace OnlineCourseReviews.Schools;

public class School
{
    public Guid Id { get; private set; }
    
    public string Name { get; private set; }
    
    public string? Description { get; private set; }
    
    public string Url { get; private set; }
    
    public bool IsVisible { get; private set; }

    public School(string name, string description, string url)
    {
        Id = Guid.NewGuid();
        Name = Guard.Against.NullOrEmpty(name);
        Description = description;
        Url = Guard.Against.NullOrEmpty(url);
        IsVisible = false;
    }
}