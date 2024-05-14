using FastEndpoints;
using Microsoft.AspNetCore.Identity;

namespace OnlineCourseReviews.Users.UserEndpoints;

public class CreateUserEndpoint(UserManager<ApplicationUser> userManager) : Endpoint<CreateUserRequest>
{
    public override void Configure()
    {
        Post("/api/users");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var newUser = new ApplicationUser()
        {
            Id = request.EmailAddress,
            Email = request.EmailAddress,
            UserName = request.EmailAddress,
            FirstName = request.FirstName,
            LastName = request.LastName
        };
        
        await userManager.CreateAsync(newUser, request.Password);

        await SendOkAsync(cancellationToken);
    }
}

public record CreateUserRequest(string FirstName, string LastName, string EmailAddress, string Password);