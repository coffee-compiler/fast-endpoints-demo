namespace Media.Api.Features.Books.CreateBook;

public sealed record CreateBookResponse
{
    public Guid Id { get; init; }

    public string Author { get; init; } = string.Empty;

    public string Genre { get; init; } = string.Empty;

    public string Title { get; init; } = string.Empty;
}
