namespace OnlineCourseReviews.Schools;

public interface ISchoolService
{
    Task<List<SchoolDto>> GetSchoolsAsync();
    
    Task<SchoolDto> GetSchoolByIdAsync(Guid schoolId);
}