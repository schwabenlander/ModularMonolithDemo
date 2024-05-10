using FastEndpoints;
using OnlineCourseReviews.Courses.Dtos;
using OnlineCourseReviews.Courses.Services;

namespace OnlineCourseReviews.Courses.CourseEndpoints.Get;

public class GetCourseByIdEndpoint(ICourseService courseService) : Endpoint<GetCourseByIdRequest, CourseDto>
{
    public override void Configure()
    {
        Get("/api/courses/{Id}");
        Claims("EmailAddress");
    }
    
    public override async Task HandleAsync(GetCourseByIdRequest request, CancellationToken cancellationToken)
    {
        var course = await courseService.GetCourseByIdAsync(request.Id);
        
        if (course is null)
        {
            await SendNotFoundAsync(cancellationToken);
            return;
        }
        
        await SendAsync(course, 200, cancellationToken);
    }
}