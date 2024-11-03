using FluentValidation;

namespace Media.Api.Features.Books.DeleteBookReview;

public sealed class DeleteBookReviewCommandValidator
    : AbstractValidator<DeleteBookReviewCommand>
{
    public DeleteBookReviewCommandValidator()
    {
        RuleFor(c => c.Request)
            .NotNull()
            .SetValidator(new DeleteBookReviewRequestValidator());
    }
}
