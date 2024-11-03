using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using FluentValidation;
using Media.Api.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Media.Api.Features.Books.GetBookReview;

public sealed class GetBookReviewQueryHandler
    : IRequestHandler<GetBookReviewQuery, Result<GetBookReviewResponse>>
{
    private readonly AppDbContext _db;
    private readonly IValidator<GetBookReviewQuery> _validator;

    public GetBookReviewQueryHandler(
        AppDbContext db,
        IValidator<GetBookReviewQuery> validator)
    {
        _db = db;
        _validator = validator;
    }

    public async Task<Result<GetBookReviewResponse>> Handle(
        GetBookReviewQuery request,
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
            .Include(b => b.Reviews)
            .AsNoTracking()
            .FirstOrDefaultAsync(
                b => b.Id == request.Request.BookId,
                cancellationToken);

        if (book is null)
        {
            return Result.NotFound();
        }

        var review = book.Reviews.Find(r => r.Id == request.Request.Id);

        if(review is null)
        {
            return Result.NotFound();
        }

        return new GetBookReviewResponse
        {
            BookId = book.Id,
            Id = review.Id,
            Comment = review.Comment.Value,
            Rating = review.Rating.ToString(),
        };
    }
}
