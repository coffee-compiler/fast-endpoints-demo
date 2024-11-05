using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using FluentValidation;
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
    private readonly IValidator<CreateBookCommand> _validator;

    public CreateBookCommandHandler(
        AppDbContext db,
        IValidator<CreateBookCommand> validator)
    {
        _db = db;
        _validator = validator;
    }

    public async Task<Result<CreateBookResponse>> Handle(
        CreateBookCommand request,
        CancellationToken cancellationToken)
    {
        var validationRes = 
            await _validator.ValidateAsync(
                request,
                cancellationToken);

        if(!validationRes.IsValid)
        {
            return Result.Invalid(validationRes.AsErrors());
        }

        var book = new Book(
            request.Request.Author,
            (BookGenre)Enum.Parse(typeof(BookGenre), request.Request.Genre),
            request.Request.Title);

        await _db.Books.AddAsync(book, cancellationToken);

        await _db.SaveChangesAsync(cancellationToken);

        return Result.Created(
            new CreateBookResponse
            {
                Id = book.Id,
                Author = book.Author,
                Genre = book.Genre.ToString(),
                Title = book.Title,
            });
    }
}
