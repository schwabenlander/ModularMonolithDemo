using FastEndpoints;
using OnlineCourseReviews.Reviews.Services;
using OnlineCourseReviews.Users;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddFastEndpoints();

// Add Module Services
builder.Services.AddUserModuleServices(builder.Configuration);
builder.Services.AddReviewServices(builder.Configuration);

var app = builder.Build();

app.UseHttpsRedirection();
app.UseFastEndpoints();

app.Run();

// Needed for tests
public partial class Program
{
    
}