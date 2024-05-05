using FastEndpoints;
using FastEndpoints.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;

namespace OnlineCourseReviews.Users.UserEndpoints;

public class LoginEndpoint(UserManager<ApplicationUser> userManager) : Endpoint<UserLoginRequest>
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;

    public override void Configure()
    {
        Post("/api/users/login");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UserLoginRequest request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.EmailAddress);
        
        if (user is null) 
        {
            await SendUnauthorizedAsync(cancellationToken);
            return;
        }
        
        var isLoginSuccessful = await _userManager.CheckPasswordAsync(user, request.Password);
    
        if (!isLoginSuccessful)
        {
            await SendUnauthorizedAsync(cancellationToken);
            return;
        }
        
        var jwtSecret = Config["Auth:JwtSecret"]!;
        var token = JwtBearer.CreateToken(options =>
        {
            options.SigningKey = jwtSecret;
            options.ExpireAt = DateTime.UtcNow.AddDays(1);
            options.User.Roles.Add();
            options.User["EmailAddress"] = request.EmailAddress;
        });
        
        await SendOkAsync(token, cancellationToken);
    }
}

public record UserLoginRequest
{
    public string EmailAddress { get; init; }
    public string Password { get; init; }
}