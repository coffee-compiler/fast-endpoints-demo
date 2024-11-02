using Ardalis.Result.AspNetCore;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Media.Api.Features.Books.CreateBookReview;

public sealed class CreateBookReviewEndpoint
    : Endpoint<CreateBookReviewRequest, Results<Created<CreateBookReviewResponse>, NotFound, BadRequest>>
{
    private readonly IMediator _sender;

    public CreateBookReviewEndpoint(IMediator sender)
        => _sender = sender;

    public override void Configure()
    {
        Post("/books/{bookId}/reviews");
        Roles("Admin");
    }

    public override async Task HandleAsync(CreateBookReviewRequest req, CancellationToken ct)
    {
        var response = await _sender.Send(
            new CreateBookReviewCommand
            {
                Request = req,
            }, ct);

        await SendResultAsync(response.ToMinimalApiResult());
    }
}
