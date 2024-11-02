using Ardalis.Result;
using MediatR;

namespace Media.Api.Features.Books.CreateBookReview;

public sealed record CreateBookReviewCommand
    : IRequest<Result<CreateBookReviewResponse>>
{
    public required CreateBookReviewRequest Request { get; init; }
}
