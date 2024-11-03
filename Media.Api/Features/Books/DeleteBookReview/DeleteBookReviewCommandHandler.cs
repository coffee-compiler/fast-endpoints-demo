using Ardalis.Result;
using Media.Api.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Media.Api.Features.Books.DeleteBookReview;

public sealed class DeleteBookReviewCommandHandler
    : IRequestHandler<DeleteBookReviewCommand, Result>
{
    private readonly AppDbContext _db;

    public DeleteBookReviewCommandHandler(AppDbContext db)
        => _db = db;

    public async Task<Result> Handle(DeleteBookReviewCommand request, CancellationToken cancellationToken)
    {
        var book =
            await _db.Books
            .Include(r => r.Reviews)
            .FirstOrDefaultAsync(
                b => b.Id == request.Request.BookId,
                cancellationToken);

        if (book is null)
        {
            return Result.NotFound();
        }

        var review = book.Reviews.Find(r => r.Id == request.Request.Id);

        if (review is null)
        {
            return Result.NotFound();
        }

        _db.Remove(review);

        await _db.SaveChangesAsync(cancellationToken);

        return Result.NoContent();
    }
}
