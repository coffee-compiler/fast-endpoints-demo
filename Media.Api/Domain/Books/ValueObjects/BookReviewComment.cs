using Ardalis.Result;
using Media.Api.Domain.Core;

namespace Media.Api.Domain.Books.ValueObjects;

public sealed class BookReviewComment : IValueObject
{
    public const int MaxLength = 1000;

    private BookReviewComment(string value)
        => Value = value;

    public string Value { get; }

    public static Result<BookReviewComment> Create(string comment)
    {
        return comment switch
        {
            var c when string.IsNullOrWhiteSpace(c) => Result.Error("The book review comment is empty."),
            var c when c.Length > MaxLength => Result.Error("The book review comment is too long."),
            _ => new BookReviewComment(comment),
        };
    }
}
