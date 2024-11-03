namespace Media.Api.Features.Books.DeleteBookReview;

public sealed record DeleteBookReviewRequest
{
    public Guid BookId { get; init; }

    public Guid Id { get; init; }
}
