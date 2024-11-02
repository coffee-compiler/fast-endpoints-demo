using Ardalis.Result;
using Media.Api.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Media.Api.Features.Books.DeleteBook;

public sealed class DeleteBookCommandHandler
    : IRequestHandler<DeleteBookCommand, Result>
{
    private readonly AppDbContext _db;

    public DeleteBookCommandHandler(AppDbContext db)
        => _db = db;

    public async Task<Result> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var book =
            await _db.Books
            .FirstOrDefaultAsync(
                b => b.Id == request.Request.Id,
                cancellationToken);

        if (book == null)
        {
            return Result.NotFound();
        }

        _db.Books.Remove(book);

        await _db.SaveChangesAsync(cancellationToken);

        return Result.NoContent();
    }
}
