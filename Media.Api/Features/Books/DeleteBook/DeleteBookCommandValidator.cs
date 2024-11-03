using FluentValidation;

namespace Media.Api.Features.Books.DeleteBook;

public sealed class DeleteBookCommandValidator
    : AbstractValidator<DeleteBookCommand>
{
    public DeleteBookCommandValidator()
    {
        RuleFor(c => c.Request)
            .NotNull()
            .SetValidator(new DeleteBookRequestValidator());
    }
}
