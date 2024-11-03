using FluentValidation;

namespace Media.Api.Features.Books.CreateBookReview;

public sealed class CreateBookReviewCommandValidator
    : AbstractValidator<CreateBookReviewCommand>
{
    public CreateBookReviewCommandValidator()
    {
        RuleFor(c => c.Request)
            .NotNull()
            .SetValidator(new CreateBookReviewRequestValidator());
    }
}
