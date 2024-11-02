﻿namespace Media.Api.Features.Books.CreateBookReview;

public sealed record CreateBookReviewResponse
{
    public Guid Id { get; init; }

    public Guid BookId { get; init; }

    public string Comment { get; init; }

    public string Rating { get; init; }
}
