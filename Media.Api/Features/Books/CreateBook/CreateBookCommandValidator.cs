using FluentValidation;

namespace Media.Api.Features.Books.CreateBook;

public sealed class CreateBookCommandValidator
    : AbstractValidator<CreateBookCommand>
{
    public CreateBookCommandValidator()
    {
        RuleFor(c => c.Request)
            .NotNull()
            .SetValidator(new CreateBookRequestValidator());
    }
}
