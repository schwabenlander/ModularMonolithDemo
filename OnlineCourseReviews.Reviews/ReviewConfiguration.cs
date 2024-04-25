using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineCourseReviews.Reviews;

internal class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    private static readonly string UserId = "sean@schwabenlander.com";
    private static readonly Guid CourseGuid = Guid.Parse("00000000-0000-0000-0000-00000000000C");
    
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.Property(p => p.ReviewText)
            .HasMaxLength(DataSchemaConstants.DEFAULT_MAX_LENGTH)
            .IsRequired();
        
        builder.Property(p => p.CourseId)
            .IsRequired();
        
        builder.Property(p => p.UserId)
            .HasMaxLength(DataSchemaConstants.DEFAULT_MAX_LENGTH)
            .IsRequired();
        
        builder.Property(p => p.Rating)
            .IsRequired();

        builder.Property(p => p.IsRecommended)
            .IsRequired();
        
        builder.Property(p => p.IsCourseCompleted)
            .IsRequired();
        
        builder.Property(p => p.CreatedAt)
            .IsRequired();

        builder.Property(p => p.IsVisible)
            .IsRequired();
        
        builder.HasData(GetSampleReviews());
    }

    private IEnumerable<Review> GetSampleReviews()
    {
        yield return new Review(CourseGuid, UserId, "Great course!", 5, true, true, 9.99m, null);
        yield return new Review(CourseGuid, UserId, "Not worth the money.", 1, false, false, 27.00m, "DISCOUNT1");
        yield return new Review(CourseGuid, UserId, "I learned a lot.", 4, true, true, 44.00m, null);
        yield return new Review(CourseGuid, UserId, "I didn't learn anything.", 2, false, false, 14.75m, "DISCOUNT2");
    }
}