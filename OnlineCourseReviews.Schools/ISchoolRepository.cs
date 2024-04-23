namespace OnlineCourseReviews.Schools;

internal interface ISchoolRepository : IReadOnlySchoolRepository
{
    Task AddAsync(School school);
    
    Task SaveChangesAsync(School school);
    
    Task DeleteAsync(Guid schoolId);
}

internal interface IReadOnlySchoolRepository
{
    Task<List<School>> GetAllAsync();
    
    Task<School> GetByIdAsync(Guid schoolId);
}