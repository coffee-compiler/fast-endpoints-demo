using FastEndpoints;
using MediatR;

namespace Media.Api.Features.Books.GetBook;

public sealed class GetBookEndpoint : Endpoint<GetBookRequest, GetBookResponse>
{
    private readonly IMediator _sender;

    public GetBookEndpoint(IMediator sender)
        => _sender = sender;

    public override void Configure()
    {
        Get("/api/books/{id:guid}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetBookRequest req, CancellationToken ct)
    {
        var response = await _sender.Send(
            new GetBookQuery
            {
                Request = req,
            }, ct);

        await SendAsync(response, cancellation: ct);
    }
}
