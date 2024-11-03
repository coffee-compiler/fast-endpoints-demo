using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Media.Api.Features.Misc.Ping;

public sealed class PingEndpoint
    : EndpointWithoutRequest<NoContent>
{
    public override void Configure()
    {
        Post("/misc/ping");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
        => await SendNoContentAsync(ct);
}
