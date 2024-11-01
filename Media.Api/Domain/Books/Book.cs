
namespace Media.Api.Domain.Books;

public sealed class Book : IAggregateRoot
{
    public Guid Id { get; init; }

    public string Author { get; init; } = string.Empty;

    public string Title { get; init; } = string.Empty;
}
