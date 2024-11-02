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

        builder.Property(b => b.Author)
            .IsRequired();

        builder.Property(b => b.Genre)
            .HasConversion(
                g => g.ToString(),
                g => (BookGenre)Enum.Parse(typeof(BookGenre), g))
            .IsRequired();

        builder.Property(b => b.Title)
            .IsRequired();
    }
}
