using FastEndpoints;
using FastEndpoints.Testing;
using FluentAssertions;
using OnlineCourseReviews.Reviews.ReviewEndpoints;
using Xunit.Abstractions;

namespace OnlineCourseReviews.Reviews.Tests.Endpoints;

public class GetReviews(Fixture fixture, ITestOutputHelper outputHelper) : TestBase<Fixture>
{
    [Fact]
    public async Task GetReviews_Returns_Success_Status_Code()
    {
        // Arrange
        var client = fixture.Client;
        
        // Act
        var result = await client.GETAsync<GetReviewsEndpoint, GetReviewsResponse>();
        
        // Assert
        result.Response.EnsureSuccessStatusCode();
    }
    
    [Fact]
    public async Task GetReviews_Returns_Four_Reviews()
    {
        // Arrange
        var client = fixture.Client;
        
        // Act
        var result = await client.GETAsync<GetReviewsEndpoint, GetReviewsResponse>();
        
        // Assert
        result.Result.Reviews.Count.Should().Be(4);
    }
}