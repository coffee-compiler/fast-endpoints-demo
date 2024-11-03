using FluentValidation;
using Media.Api.Domain.Books.Enums;

namespace Media.Api.Features.Books.CreateBook;

public sealed class CreateBookRequestValidator
    : AbstractValidator<CreateBookRequest>
{
    public CreateBookRequestValidator()
    {
        RuleFor(r => r.Author)
            .NotEmpty();

        RuleFor(r => r.Genre)
            .NotEmpty()
            .IsEnumName(typeof(BookGenre));

        RuleFor(r => r.Title)
            .NotEmpty();
    }
}
