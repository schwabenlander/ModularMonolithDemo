using Microsoft.EntityFrameworkCore;
using OnlineCourseReviews.Courses.Data;
using OnlineCourseReviews.Courses.Models;

namespace OnlineCourseReviews.Courses.Repositories;

public class EfCourseRepository(CoursesDbContext dbContext) : ICourseRepository
{
    public async Task<IEnumerable<Course>> GetAllAsync()
    {
        return await dbContext.Courses.ToListAsync();
    }

    public async Task<Course?> GetByIdAsync(Guid id)
    {
        return await dbContext.Courses.FindAsync(id);
    }

    public async Task<Course> AddAsync(Course course)
    {
        var addedCourse = (await dbContext.Courses.AddAsync(course)).Entity;
        await dbContext.SaveChangesAsync();

        return addedCourse;
    }

    public async Task<Course> UpdateAsync(Course course)
    {
        var updatedCourse = dbContext.Courses.Update(course).Entity;
        await dbContext.SaveChangesAsync();

        return updatedCourse;
    }

    public async Task DeleteAsync(Course course)
    {
        dbContext.Courses.Remove(course);
        await dbContext.SaveChangesAsync();
    }
}