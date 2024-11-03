using Ardalis.Result.AspNetCore;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Media.Api.Features.Books.GetBookReview;

public sealed class GetBookReviewEndpoint
    : Endpoint<GetBookReviewRequest, Results<Ok<GetBookReviewResponse>, NotFound, BadRequest>>
{
    private readonly IMediator _sender;

    public GetBookReviewEndpoint(IMediator sender)
        => _sender = sender;

    public override void Configure()
    {
        Get("/books/{bookId:guid}/reviews/{id:guid}");
        Roles("Admin");
    }

    public override async Task HandleAsync(GetBookReviewRequest req, CancellationToken ct)
    {
        var response = await _sender.Send(
            new GetBookReviewQuery
            {
                Request = req,
            }, ct);

        await SendResultAsync(response.ToMinimalApiResult());
    }
}
