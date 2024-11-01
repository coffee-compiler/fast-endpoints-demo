using Mapster;
using Media.Api.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Media.Api.Features.Books.GetBook;

public sealed class GetBookCommandHandler : IRequestHandler<GetBookCommand, GetBookResponse>
{
    private readonly AppDbContext _db;

    public GetBookCommandHandler(AppDbContext db)
        => _db = db;

    public async Task<GetBookResponse> Handle(GetBookCommand request, CancellationToken cancellationToken)
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
