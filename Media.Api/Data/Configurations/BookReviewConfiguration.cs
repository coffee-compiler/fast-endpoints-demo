using Media.Api.Domain.Books.Entities;
using Media.Api.Domain.Books.Enums;
using Media.Api.Domain.Books.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Media.Api.Data.Configurations;

public sealed class BookReviewConfiguration : IEntityTypeConfiguration<BookReview>
{
    public void Configure(EntityTypeBuilder<BookReview> builder)
    {
        builder.HasKey(r => r.Id);

        builder.OwnsOne(
            r => r.Comment,
            commentBuilder =>
            {
                commentBuilder.Property(c => c.Value)
                .HasMaxLength(BookReviewComment.MaxLength)
                .IsRequired();
            });

        builder.Property(r => r.Rating)
             .HasConversion(
                r => r.ToString(),
                r => (BookReviewRating)Enum.Parse(typeof(BookReviewRating), r))
            .IsRequired();
    }
}
