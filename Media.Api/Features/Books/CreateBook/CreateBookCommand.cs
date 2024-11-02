using Ardalis.Result;
using MediatR;

namespace Media.Api.Features.Books.CreateBook;

public sealed record CreateBookCommand 
    : IRequest<Result<CreateBookResponse>>
{
    public required CreateBookRequest Request { get; init; }
}
