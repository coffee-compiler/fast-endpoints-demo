namespace Media.Api.Features.Books.DeleteBook;

public sealed record DeleteBookRequest
{
    public Guid Id { get; init; }
}
