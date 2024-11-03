using FluentValidation;

namespace Media.Api.Features.Books.GetBook;

public sealed class GetBookRequestValidator
    : AbstractValidator<GetBookRequest>
{
    public GetBookRequestValidator()
        => RuleFor(r => r.Id).NotEmpty();
}
