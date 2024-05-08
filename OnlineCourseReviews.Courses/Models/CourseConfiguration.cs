using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineCourseReviews.Courses.Models;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    private static readonly Guid SchoolId = Guid.Parse("00000000-0000-0000-0000-000000000010");
    private static readonly Guid Course1Guid = Guid.Parse("00000000-0000-0000-0000-00000000000C");
    private static readonly Guid Course2Guid = Guid.Parse("00000000-0000-0000-0000-00000000000D");
    private static readonly Guid Course3Guid = Guid.Parse("00000000-0000-0000-0000-00000000000E");
    private static readonly Guid Course4Guid = Guid.Parse("00000000-0000-0000-0000-00000000000F");
    
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.Property(p => p.Title)
            .HasMaxLength(DataSchemaConstants.DEFAULT_MAX_LENGTH)
            .IsRequired();

        builder.Property(p => p.Description)
            .HasMaxLength(DataSchemaConstants.LONG_TEXT_MAX_LENGTH)
            .IsRequired();

        builder.Property(p => p.Instructor)
            .HasMaxLength(DataSchemaConstants.DEFAULT_MAX_LENGTH)
            .IsRequired();

        builder.Property(p => p.Url)
            .HasMaxLength(DataSchemaConstants.URL_MAX_LENGTH)
            .IsRequired();
        
        builder.HasData(GetSampleCourses());
    }

    private IEnumerable<Course> GetSampleCourses()
    {
        yield return new Course(Course1Guid, SchoolId, "Introduction to Programming", "Learn the basics of programming.", "Nick Chapsas", 69.99m, "https://example.com/courses/intro-to-programming");
        yield return new Course(Course2Guid, SchoolId, "Advanced Programming", "Take your programming skills to the next level.", "Nick Chapsas", 99.99m, "https://example.com/courses/advanced-programming");
        yield return new Course(Course3Guid, SchoolId, "Introduction to Web Development", "Learn how to build websites.", "Nick Chapsas", 49.99m, "https://example.com/courses/intro-to-web-dev");
        yield return new Course(Course4Guid, SchoolId, "Advanced Web Development", "Learn how to build advanced websites.", "Nick Chapsas", 79.99m, "https://example.com/courses/advanced-web-dev");
    }
}