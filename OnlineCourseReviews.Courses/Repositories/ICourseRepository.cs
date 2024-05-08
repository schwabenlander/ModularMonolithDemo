using OnlineCourseReviews.Courses.Models;

namespace OnlineCourseReviews.Courses.Repositories;

public interface ICourseRepository
{
    Task<IEnumerable<Course>> GetAllAsync();
    Task<Course?> GetByIdAsync(Guid id);
    Task<Course> AddAsync(Course course);
    Task<Course> UpdateAsync(Course course);
    Task DeleteAsync(Course course);
}