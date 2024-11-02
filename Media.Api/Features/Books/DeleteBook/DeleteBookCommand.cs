using Ardalis.Result;
using MediatR;

namespace Media.Api.Features.Books.DeleteBook;

public sealed record DeleteBookCommand
    : IRequest<Result>
{
    public required DeleteBookRequest Request { get; init; }
}
