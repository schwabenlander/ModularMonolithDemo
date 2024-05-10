using FastEndpoints;
using OnlineCourseReviews.Courses.CourseEndpoints.Get;
using OnlineCourseReviews.Courses.Dtos;
using OnlineCourseReviews.Courses.Services;

namespace OnlineCourseReviews.Courses.CourseEndpoints.Add;

public class AddCourseEndpoint(ICourseService courseService) : Endpoint<AddCourseRequest>
{
    public override void Configure()
    {
        Post("/api/courses");
        Claims("EmailAddress");
    }

    public override async Task HandleAsync(AddCourseRequest request, CancellationToken cancellationToken)
    {
        var course = new CourseDto(Guid.NewGuid(),
            request.SchoolId,
            request.Title,
            request.Description,
            request.Instructor,
            request.Price,
            request.Url);
        
        var addedCourse = await courseService.AddCourseAsync(course);
        await SendCreatedAtAsync<GetCourseByIdEndpoint>(new { id = addedCourse.Id }, addedCourse);
    }
}