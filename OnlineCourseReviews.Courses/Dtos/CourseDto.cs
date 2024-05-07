namespace OnlineCourseReviews.Courses.Dtos;

public record CourseDto(Guid? Id, 
    Guid SchoolId,
    string Title, 
    string Description, 
    string Instructor, 
    decimal Price, 
    string Url);