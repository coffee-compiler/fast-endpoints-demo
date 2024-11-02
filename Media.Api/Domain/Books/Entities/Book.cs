using Media.Api.Domain.Books.Enums;

namespace Media.Api.Domain.Books.Entities;

public sealed class Book : IAggregateRoot
{
    public Book(
        string author,
        BookGenre genre,
        string title)
    {
        Id = Guid.NewGuid();
        Author = author;
        Genre = genre;
        Title = title;
    }

    public Guid Id { get; }

    public string Author { get; }

    public BookGenre Genre { get; }

    public string Title { get; }
}
