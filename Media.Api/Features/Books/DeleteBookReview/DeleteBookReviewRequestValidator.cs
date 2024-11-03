using FluentValidation;

namespace Media.Api.Features.Books.DeleteBookReview;

public sealed class DeleteBookReviewRequestValidator
    : AbstractValidator<DeleteBookReviewRequest>
{
    public DeleteBookReviewRequestValidator()
    {
        RuleFor(r => r.BookId)
            .NotEmpty();

        RuleFor(r => r.Id)
            .NotEmpty();
    }
}
