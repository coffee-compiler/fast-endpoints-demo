using Mapster;
using Media.Api.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Media.Api.Features.Books.GetBook;

public sealed class GetBookQueryHandler : IRequestHandler<GetBookQuery, GetBookResponse>
{
    private readonly AppDbContext _db;

    public GetBookQueryHandler(AppDbContext db)
        => _db = db;

    public async Task<GetBookResponse> Handle(GetBookQuery request, CancellationToken cancellationToken)
    {
        var book =
            await _db.Books
            .AsNoTracking()
            .FirstOrDefaultAsync(
                b => b.Id == request.Request.Id,
                cancellationToken);

        return book.Adapt<GetBookResponse>();
    }
}
