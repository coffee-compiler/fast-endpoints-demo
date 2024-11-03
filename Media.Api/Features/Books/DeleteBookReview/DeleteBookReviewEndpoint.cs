using Ardalis.Result.AspNetCore;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Media.Api.Features.Books.DeleteBookReview;

public sealed class DeleteBookReviewEndpoint
    : Endpoint<DeleteBookReviewRequest, Results<NoContent, NotFound, BadRequest>>
{
    private readonly IMediator _sender;

    public DeleteBookReviewEndpoint(IMediator sender)
        => _sender = sender;

    public override void Configure()
    {
        Delete("/books/{bookId:guid}/reviews/{id:guid}");
        Roles("Admin");
    }

    public override async Task HandleAsync(DeleteBookReviewRequest req, CancellationToken ct)
    {
        var response = await _sender.Send(
            new DeleteBookReviewCommand
            {
                Request = req,
            }, ct);

        await SendResultAsync(response.ToMinimalApiResult());
    }
}
