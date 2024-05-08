namespace OnlineCourseReviews.Schools;

public interface ISchoolRepository : IReadOnlySchoolRepository
{
    Task AddAsync(School school);
    
    Task SaveChangesAsync(School school);
    
    Task DeleteAsync(Guid schoolId);
}

public interface IReadOnlySchoolRepository
{
    Task<List<School>> GetAllAsync();
    
    Task<School> GetByIdAsync(Guid schoolId);
}