using Ardalis.GuardClauses;
using OnlineCourseReviews.Courses.Dtos;
using OnlineCourseReviews.Courses.Models;
using OnlineCourseReviews.Courses.Repositories;

namespace OnlineCourseReviews.Courses.Services;

public class CourseService(ICourseRepository courseRepository) : ICourseService
{
    public async Task<List<CourseDto>> GetCoursesAsync()
    {
        var courses = await courseRepository.GetAllAsync();
        var courseDtos = courses.Select(course => new CourseDto(course.Id,
            course.SchoolId,
            course.Title,
            course.Description,
            course.Instructor,
            course.Price,
            course.Url)).ToList();
        
        return courseDtos;
    }

    public async Task<CourseDto?> GetCourseByIdAsync(Guid courseId)
    {
        var course = await courseRepository.GetByIdAsync(courseId);
        
        if (course is null)
        {
            return null;
        }
        
        var courseDto = new CourseDto(courseId,
            course.SchoolId,
            course.Title,
            course.Description,
            course.Instructor,
            course.Price,
            course.Url);
        
        return courseDto;
    }

    public async Task<CourseDto> AddCourseAsync(CourseDto courseDto)
    {
        var course = new Course(courseDto.Id ?? Guid.NewGuid(),
            courseDto.SchoolId,
            courseDto.Title,
            courseDto.Description,
            courseDto.Instructor,
            courseDto.Price,
            courseDto.Url);
        
        var addedCourse = await courseRepository.AddAsync(course);
        
        return addedCourse.ToDto();
    }

    public async Task<CourseDto> UpdateCourseAsync(CourseDto courseDto)
    {
        if (courseDto.Id is null)
        {
            throw new ArgumentNullException(nameof(courseDto.Id));
        }
        
        var course = await courseRepository.GetByIdAsync(courseDto.Id.Value);
        
        if (course is null)
        {
            throw new NotFoundException(courseDto.Id.ToString()!, nameof(courseDto));
        }
        
        course.Update(
            courseDto.SchoolId,
            courseDto.Title,
            courseDto.Description,
            courseDto.Instructor,
            courseDto.Price,
            courseDto.Url);
        
        var updatedCourse = await courseRepository.UpdateAsync(course);
        
        return updatedCourse.ToDto();
    }

    public async Task DeleteCourseAsync(Guid courseId)
    {
        var course = await courseRepository.GetByIdAsync(courseId);
        
        if (course is null)
        {
            throw new NotFoundException(courseId.ToString(), nameof(courseId));
        }
        
        await courseRepository.DeleteAsync(course);
    }

    public async Task<bool> CourseExistsAsync(Guid courseId)
    {
        var course = await courseRepository.GetByIdAsync(courseId);
        return course is not null;
    }
}