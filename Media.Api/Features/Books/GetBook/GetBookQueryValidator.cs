using FluentValidation;

namespace Media.Api.Features.Books.GetBook;

public sealed class GetBookQueryValidator
    : AbstractValidator<GetBookQuery>
{
    public GetBookQueryValidator()
    {
        RuleFor(q => q.Request)
            .NotNull()
            .SetValidator(new GetBookRequestValidator());
    }
}
