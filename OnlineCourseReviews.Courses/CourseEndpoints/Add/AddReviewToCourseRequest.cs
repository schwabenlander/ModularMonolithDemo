using FastEndpoints;

namespace OnlineCourseReviews.Courses.CourseEndpoints.Add;

public record AddReviewToCourseRequest(Guid CourseId, Guid ReviewId);