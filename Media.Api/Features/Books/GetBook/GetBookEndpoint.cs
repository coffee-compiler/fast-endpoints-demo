using Ardalis.Result.AspNetCore;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Media.Api.Features.Books.GetBook;

public sealed class GetBookEndpoint
    : Endpoint<GetBookRequest, Results<Ok<GetBookResponse>, NotFound, BadRequest>>
{
    private readonly IMediator _sender;

    public GetBookEndpoint(IMediator sender)
        => _sender = sender;

    public override void Configure()
    {
        Get("/books/{id:guid}");
        Roles("Admin");
    }

    public override async Task HandleAsync(GetBookRequest req, CancellationToken ct)
    {
        var response = await _sender.Send(
            new GetBookQuery
            {
                Request = req,
            }, ct);

        await SendResultAsync(response.ToMinimalApiResult());
    }
}
