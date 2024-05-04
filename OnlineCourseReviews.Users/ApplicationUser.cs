using Microsoft.AspNetCore.Identity;

namespace OnlineCourseReviews.Users;

public class ApplicationUser : IdentityUser<string>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}