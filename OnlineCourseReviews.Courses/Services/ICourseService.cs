using OnlineCourseReviews.Courses.Dtos;

namespace OnlineCourseReviews.Courses.Services;

public interface ICourseService
{
    Task<List<CourseDto>> GetCoursesAsync();
    
    Task<CourseDto?> GetCourseByIdAsync(Guid courseId);
    
    Task<CourseDto> AddCourseAsync(CourseDto courseDto);
    
    Task<CourseDto> UpdateCourseAsync(CourseDto courseDto);
    
    Task DeleteCourseAsync(Guid courseId);
    
    Task<bool> CourseExistsAsync(Guid courseId);
}