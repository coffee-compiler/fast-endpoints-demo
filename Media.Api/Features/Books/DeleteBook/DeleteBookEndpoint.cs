using Ardalis.Result.AspNetCore;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Media.Api.Features.Books.DeleteBook;

public sealed class DeleteBookEndpoint
    : Endpoint<DeleteBookRequest, Results<NoContent, BadRequest>>
{
    private readonly IMediator _sender;

    public DeleteBookEndpoint(IMediator sender)
        => _sender = sender;

    public override void Configure()
    {
        Delete("/books/{id:guid}");
        Roles("Admin");
    }

    public override async Task HandleAsync(DeleteBookRequest req, CancellationToken ct)
    {
        var response = await _sender.Send(
            new DeleteBookCommand
            {
                Request = req,
            }, ct);

        await SendResultAsync(response.ToMinimalApiResult());
    }
}
