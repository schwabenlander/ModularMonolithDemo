using FastEndpoints;
using FluentValidation;

namespace OnlineCourseReviews.Reviews.ReviewEndpoints.Update;

internal class UpdateReviewRequestValidator : Validator<UpdateReviewRequest>
{
    public UpdateReviewRequestValidator()
    {
        RuleFor(review => review.Id)
            .NotEmpty()
            .WithMessage("Review Id is required");
        
        RuleFor(review => review.CourseId)
            .NotEmpty()
            .WithMessage("Course Id is required");
        
        RuleFor(review => review.UserId)
            .NotEmpty()
            .WithMessage("User Id is required");
        
        RuleFor(review => review.ReviewText)
            .NotEmpty()
            .WithMessage("Review text is required");
        
        RuleFor(review => review.Rating)
            .InclusiveBetween(1, 5)
            .WithMessage("Rating must be a number between 1 and 5");

        RuleFor(review => review.PricePaid)
            .GreaterThanOrEqualTo(0)
            .When(review => review.PricePaid.HasValue)
            .WithMessage("Price paid must be greater than or equal to $0.00");
    }
}