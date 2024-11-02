using Ardalis.Result;
using MediatR;

namespace Media.Api.Features.Books.GetBook;

public sealed record GetBookQuery
    : IRequest<Result<GetBookResponse>>
{
    public required GetBookRequest Request { get; init; }
}
