using FastEndpoints;
using OnlineCourseReviews.Courses.Services;

namespace OnlineCourseReviews.Courses.CourseEndpoints.Get;

public class GetCoursesEndpoint(ICourseService courseService) : EndpointWithoutRequest<GetCoursesResponse>
{
    public override void Configure()
    {
        Get("/api/courses");
        Claims("EmailAddress");
    }
    
    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var courses = await courseService.GetCoursesAsync();
        var response = new GetCoursesResponse { Courses = courses.ToList() };
        
        await SendAsync(response, 200, cancellationToken);
    }
}