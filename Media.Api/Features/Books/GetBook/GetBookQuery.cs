using MediatR;

namespace Media.Api.Features.Books.GetBook;

public sealed record GetBookCommand : IRequest<GetBookResponse>
{
    public required GetBookRequest Request { get; init; }
}
