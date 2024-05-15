using FastEndpoints;
using OnlineCourseReviews.Courses.Services;

namespace OnlineCourseReviews.Courses.CourseEndpoints.Add;

public class AddReviewToCourseEndpoint(ICourseService courseService) : Endpoint<AddReviewToCourseRequest>
{
    public override void Configure()
    {
        Verbs(Http.POST);
        Claims("EmailAddress");
        Routes("/api/courses/{courseId}/reviews");
    }
    
    public override async Task HandleAsync(AddReviewToCourseRequest request, CancellationToken cancellationToken)
    {
        await courseService.AddReviewAsync(request.CourseId, request);
        await SendOkAsync(cancellationToken);
    }
}