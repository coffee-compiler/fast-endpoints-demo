using FluentValidation;

namespace Media.Api.Features.Books.GetBookReview;

public sealed class GetBookReviewQueryValidator
    : AbstractValidator<GetBookReviewQuery>
{
    public GetBookReviewQueryValidator()
    {
        RuleFor(q => q.Request)
            .NotNull()
            .SetValidator(new GetBookReviewRequestValidator());
    }
}
