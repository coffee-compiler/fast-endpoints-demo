﻿namespace Media.Api.Features.Books.CreateBookReview;

public sealed record CreateBookReviewRequest
{
    public Guid BookId { get; init; }

    public string Comment { get; init; } = string.Empty;

    public string Rating { get; init; } = string.Empty;
}
