using Ardalis.Result;
using MediatR;

namespace Media.Api.Features.Books.DeleteBookReview;

public sealed record DeleteBookReviewCommand
    : IRequest<Result>
{
    public required DeleteBookReviewRequest Request { get; init; }
}
