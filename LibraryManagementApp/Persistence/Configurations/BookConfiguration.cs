using LibraryManagementApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagementApp.Persistence.Configurations;

public class BookConfiguration: IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        /*builder.Property(b => b.Id)
            .IsRequired();
        builder.HasOne<Author>(b => b.Author)
            .WithMany(a => a.Books)
            .HasForeignKey(b => b.AuthorId);*/
    }
}