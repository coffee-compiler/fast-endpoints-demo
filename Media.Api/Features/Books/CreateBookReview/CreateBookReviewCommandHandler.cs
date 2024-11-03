using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using FluentValidation;
using Media.Api.Data;
using Media.Api.Domain.Books.Entities;
using Media.Api.Domain.Books.Enums;
using Media.Api.Domain.Books.ValueObjects;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Media.Api.Features.Books.CreateBookReview;

public sealed class CreateBookReviewCommandHandler
    : IRequestHandler<CreateBookReviewCommand, Result<CreateBookReviewResponse>>
{
    private readonly AppDbContext _db;
    private readonly IValidator<CreateBookReviewCommand> _validator;

    public CreateBookReviewCommandHandler(
        AppDbContext db,
        IValidator<CreateBookReviewCommand> validator)
    {
        _db = db;
        _validator = validator;
    }

    public async Task<Result<CreateBookReviewResponse>> Handle(
        CreateBookReviewCommand request,
        CancellationToken cancellationToken)
    {
        var validationRes =
            await _validator.ValidateAsync(
                request,
                cancellationToken);

        if (!validationRes.IsValid)
        {
            return Result.Invalid(validationRes.AsErrors());
        }

        var commentRes = BookReviewComment.Create(request.Request.Comment);

        if(commentRes.IsError())
        {
            return Result.Error();
        }

        var book =
            await _db.Books
            .FirstOrDefaultAsync(
                b => b.Id == request.Request.BookId,
                cancellationToken);

        if(book is null)
        {
            return Result.NotFound();
        }

        var bookReview = new BookReview(
            book.Id,
            commentRes.Value,
            (BookReviewRating)Enum.Parse(typeof(BookReviewRating), request.Request.Rating));

        await _db.AddAsync(bookReview, cancellationToken);

        await _db.SaveChangesAsync(cancellationToken);

        return Result.Created(
            new CreateBookReviewResponse
            {
                Id = bookReview.Id,
                BookId = bookReview.BookId,
                Comment = bookReview.Comment.Value,
                Rating = bookReview.Rating.ToString(),
            });
    }
}
