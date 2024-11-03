namespace Media.Api.Features.Books.GetBookReview;

public sealed record GetBookReviewRequest
{
    public Guid BookId { get; init; }

    public Guid Id { get; init; }
}
