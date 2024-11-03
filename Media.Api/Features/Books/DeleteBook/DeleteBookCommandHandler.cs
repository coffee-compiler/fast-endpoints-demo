using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using FluentValidation;
using Media.Api.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Media.Api.Features.Books.DeleteBook;

public sealed class DeleteBookCommandHandler
    : IRequestHandler<DeleteBookCommand, Result>
{
    private readonly AppDbContext _db;
    private readonly IValidator<DeleteBookCommand> _validator;

    public DeleteBookCommandHandler(
        AppDbContext db,
        IValidator<DeleteBookCommand> validator)
    {
        _db = db;
        _validator = validator;
    }

    public async Task<Result> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var validationRes =
            await _validator.ValidateAsync(
                request,
                cancellationToken);

        if(!validationRes.IsValid)
        {
            return Result.Invalid(validationRes.AsErrors());
        }

        var book =
            await _db.Books
            .FirstOrDefaultAsync(
                b => b.Id == request.Request.Id,
                cancellationToken);

        if (book is null)
        {
            return Result.NotFound();
        }

        _db.Books.Remove(book);

        await _db.SaveChangesAsync(cancellationToken);

        return Result.NoContent();
    }
}
