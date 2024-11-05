using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using FluentValidation;
using Mapster;
using Media.Api.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Media.Api.Features.Books.GetBook;

public sealed class GetBookQueryHandler
    : IRequestHandler<GetBookQuery, Result<GetBookResponse>>
{
    private readonly AppDbContext _db;
    private readonly IValidator<GetBookQuery> _validator;

    public GetBookQueryHandler(
        AppDbContext db,
        IValidator<GetBookQuery> validator)
    {
        _db = db;
        _validator = validator;
    }

    public async Task<Result<GetBookResponse>> Handle(
        GetBookQuery request,
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

        var book =
            await _db.Books
            .AsNoTracking()
            .FirstOrDefaultAsync(
                b => b.Id == request.Request.Id,
                cancellationToken);

        if(book is null)
        {
            return Result<GetBookResponse>.NotFound();
        }

        return new GetBookResponse
        {
            Id = book.Id,
            Author = book.Author,
            Title = book.Title,
        };
    }
}
