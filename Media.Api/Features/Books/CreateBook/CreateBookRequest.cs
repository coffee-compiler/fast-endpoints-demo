namespace Media.Api.Features.Books.CreateBook;

public sealed record CreateBookRequest
{
    public string Author { get; init; } = string.Empty;

    public string Genre {  get; init; } = string.Empty;

    public string Title { get; init; } = string.Empty;
}
