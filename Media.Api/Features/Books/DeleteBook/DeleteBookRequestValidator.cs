using FluentValidation;

namespace Media.Api.Features.Books.DeleteBook;

public sealed class DeleteBookRequestValidator
    : AbstractValidator<DeleteBookRequest>
{
    public DeleteBookRequestValidator()
        => RuleFor(r => r.Id).NotEmpty();
}
