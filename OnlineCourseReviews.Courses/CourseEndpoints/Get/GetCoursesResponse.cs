using OnlineCourseReviews.Courses.Dtos;

namespace OnlineCourseReviews.Courses.CourseEndpoints.Get;

public class GetCoursesResponse
{
    public List<CourseDto> Courses { get; set; } = new();
}