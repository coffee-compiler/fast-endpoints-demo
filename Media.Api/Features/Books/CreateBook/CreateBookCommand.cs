using MediatR;

namespace Media.Api.Features.Books.CreateBook;

public sealed record CreateBookCommand : IRequest<CreateBookResponse>
{
    public required CreateBookRequest Request { get; init; }
}
