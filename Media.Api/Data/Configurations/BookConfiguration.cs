using Media.Api.Domain.Books.Entities;
using Media.Api.Domain.Books.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Media.Api.Data.Configurations;

public sealed class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(b => b.Id);

        builder.HasMany(b => b.Reviews)
            .WithOne()
            .HasForeignKey(r => r.BookId);

        builder.Property(b => b.Author)
            .IsRequired();

        builder.Property(b => b.Genre)
            .HasConversion(
                g => g.ToString(),
                g => Enum.Parse<BookGenre>(g))
            .IsRequired();

        builder.Property(b => b.Title)
            .IsRequired();
    }
}
