using FastEndpoints;
using MediatR;

namespace Media.Api.Features.Books.CreateBook;

public sealed class CreateBookEndpoint : Endpoint<CreateBookRequest, CreateBookResponse>
{
    private readonly IMediator _sender;

    public CreateBookEndpoint(IMediator sender)
        => _sender = sender;

    public override void Configure()
    {
        Post("/api/books");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateBookRequest req, CancellationToken ct)
    {
        var response = await _sender.Send(
            new CreateBookCommand
            {
                Request = req,
            }, ct);

        await SendAsync(response, cancellation: ct);
    }
}
