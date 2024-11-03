using FluentValidation;

namespace Media.Api.Features.Books.GetBookReview;

public sealed class GetBookReviewRequestValidator
    : AbstractValidator<GetBookReviewRequest>
{
    public GetBookReviewRequestValidator()
    {
        RuleFor(r => r.BookId)
            .NotEmpty();

        RuleFor(r => r.Id)
            .NotEmpty();
    }
}
