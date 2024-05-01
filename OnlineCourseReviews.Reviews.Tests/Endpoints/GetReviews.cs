using FastEndpoints;
using FastEndpoints.Testing;
using FluentAssertions;
using OnlineCourseReviews.Reviews.Dtos;
using OnlineCourseReviews.Reviews.ReviewEndpoints;
using OnlineCourseReviews.Reviews.ReviewEndpoints.Get;
using Xunit.Abstractions;

namespace OnlineCourseReviews.Reviews.Tests.Endpoints;

public class GetReviews(Fixture fixture) : TestBase<Fixture>
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
    
    [Theory]
    [InlineData("00000000-0000-0000-0000-000000000001", "Great course!")]
    [InlineData("00000000-0000-0000-0000-000000000002", "Not worth the money.")]
    [InlineData("00000000-0000-0000-0000-000000000003", "I learned a lot.")]
    [InlineData("00000000-0000-0000-0000-000000000004", "I didn't learn anything.")]
    public async Task GetReviewById_Returns_Expected_Review_Given_Id(string reviewId, string expectedReviewText)
    {
        // Arrange
        var id = Guid.Parse(reviewId);
        var client = fixture.Client;
        var request = new GetReviewByIdRequest(id);
        
        // Act
        var result = await client.GETAsync<GetReviewByIdEndpoint, GetReviewByIdRequest, ReviewDto>(request);
        
        // Assert
        result.Response.EnsureSuccessStatusCode();
        result.Result.ReviewText.Should().Be(expectedReviewText);
    }
}