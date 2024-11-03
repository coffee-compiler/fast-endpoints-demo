using Ardalis.Result;
using MediatR;

namespace Media.Api.Features.Books.GetBookReview;

public sealed record GetBookReviewQuery
    : IRequest<Result<GetBookReviewResponse>>
{
    public required GetBookReviewRequest Request { get; init; }
}
