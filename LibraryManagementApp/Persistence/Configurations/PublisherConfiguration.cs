using LibraryManagementApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagementApp.Persistence.Configurations;

public class PublisherConfiguration: IEntityTypeConfiguration<Publisher>
{
    public void Configure(EntityTypeBuilder<Publisher> builder)
    {
        builder.Property(p => p.Id)
            .IsRequired();
        builder.HasMany(p => p.Books)
            .WithOne();
    }
}