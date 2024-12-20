﻿
using Media.Api.Domain.Books.Enums;
using Media.Api.Domain.Books.ValueObjects;
using Media.Api.Domain.Core;

namespace Media.Api.Domain.Books.Entities;

public sealed class BookReview : IEntity
{
#pragma warning disable CS8618 // Used by EF Core
    private BookReview()
#pragma warning restore CS8618 
    {
    }

    public BookReview(
        Guid bookId,
        BookReviewComment comment,
        BookReviewRating rating)
    {
        Id = Guid.NewGuid();
        BookId = bookId;
        Comment = comment;
        Rating = rating;
    }

    public Guid Id { get; }

    public Guid BookId { get; }

    public BookReviewComment Comment { get; }

    public BookReviewRating Rating { get; }
}
