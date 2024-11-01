namespace Media.Api.Features.Books.GetBook;

public sealed record GetBookRequest
{
    public Guid Id { get; init; }
}
