using FluentValidation;
using Media.Api.Domain.Books.Enums;

namespace Media.Api.Features.Books.CreateBookReview;

public sealed class CreateBookReviewRequestValidator
    : AbstractValidator<CreateBookReviewRequest>
{
    public CreateBookReviewRequestValidator()
    {
        RuleFor(r => r.BookId)
            .NotEmpty();

        RuleFor(r => r.Comment)
            .NotEmpty();

        RuleFor(r => r.Rating)
            .NotEmpty()
            .IsEnumName(typeof(BookReviewRating));
    }
}
