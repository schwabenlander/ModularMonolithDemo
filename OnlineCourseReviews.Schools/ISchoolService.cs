namespace OnlineCourseReviews.Schools;

internal interface ISchoolService
{
    Task<List<SchoolDto>> GetSchoolsAsync();
    
    Task<SchoolDto> GetSchoolByIdAsync(Guid schoolId);
}