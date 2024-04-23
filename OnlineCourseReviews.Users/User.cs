using Ardalis.GuardClauses;

namespace OnlineCourseReviews.Users;

internal class User
{
    public string Username { get; private set; }
    
    public string FirstName { get; private set; }
    
    public string LastName { get; private set; }
    
    public bool IsVerified { get; private set; }
    
    public bool IsAdmin { get; private set; }

    internal User(string username, string firstName, string lastName)
    {
        Username = Guard.Against.NullOrEmpty(username);
        FirstName = Guard.Against.NullOrEmpty(firstName);
        LastName = Guard.Against.NullOrEmpty(lastName);
        IsVerified = false;
        IsAdmin = false;
    }
}