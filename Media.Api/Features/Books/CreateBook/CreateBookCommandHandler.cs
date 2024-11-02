using Ardalis.Result;
using Mapster;
using Media.Api.Data;
using Media.Api.Domain.Books.Entities;
using Media.Api.Domain.Books.Enums;
using MediatR;

namespace Media.Api.Features.Books.CreateBook;

public sealed class CreateBookCommandHandler
    : IRequestHandler<CreateBookCommand, Result<CreateBookResponse>>
{
    private readonly AppDbContext _db;

    public CreateBookCommandHandler(AppDbContext db)
        => _db = db;

    public async Task<Result<CreateBookResponse>> Handle(
        CreateBookCommand request,
        CancellationToken cancellationToken)
    {
        var book = new Book(
            request.Request.Author,
            (BookGenre)Enum.Parse(typeof(BookGenre), request.Request.Genre),
            request.Request.Title);

        await _db.Books.AddAsync(book, cancellationToken);

        await _db.SaveChangesAsync(cancellationToken);

        return Result.Created(
            book.Adapt<CreateBookResponse>());
    }
}
