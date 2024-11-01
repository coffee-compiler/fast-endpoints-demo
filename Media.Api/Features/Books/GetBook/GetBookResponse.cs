namespace Media.Api.Features.Books.GetBook;

public sealed record GetBookResponse
{
    public Guid Id { get; init; }

    public string Author { get; init; } = string.Empty;

    public string Title { get; init; } = string.Empty;
}
