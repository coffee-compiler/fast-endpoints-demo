using Ardalis.Result;
using Mapster;
using Media.Api.Data;
using Media.Api.Domain.Books;
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
        var book = new Book
        {
            Id = Guid.NewGuid(),
            Author = request.Request.Author,
            Title = request.Request.Title,
        };

        _db.Books.Add(book);

        await _db.SaveChangesAsync(cancellationToken);

        return Result.Created(
            book.Adapt<CreateBookResponse>());
    }
}
