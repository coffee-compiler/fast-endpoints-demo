using FastEndpoints;

namespace Media.Api.Features.Books.CreateBook;

public sealed class CreateBookEndpoint : Endpoint<CreateBookRequest, CreateBookResponse>
{
    public override void Configure()
    {
        Post("/api/books");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateBookRequest req, CancellationToken ct)
    {
        await SendAsync(new CreateBookResponse
        {
            Id = Guid.NewGuid(),
            Author = req.Author,
            Title = req.Title,
        });
    }
}
