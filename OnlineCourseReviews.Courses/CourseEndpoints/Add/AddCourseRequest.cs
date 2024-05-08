namespace OnlineCourseReviews.Courses.CourseEndpoints.Add;

public record AddCourseRequest(
    Guid SchoolId,
    string Title,
    string Description,
    string Instructor,
    decimal Price,
    string Url);