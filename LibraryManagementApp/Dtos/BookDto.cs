using LibraryManagementApp.Domain;

namespace LibraryManagementApp.Dtos;

public record BookDto
{
    public Guid Id { get; init; }
    public string Title{get; init;}
    public string CopyrightNotice{get; init;}
    public int ISBN{get; init;}
    public string AuthorName { get; init; }
    public Guid AuthourId { get; init; }
    public int PageLength{get; init;}
    public Language Language{get; init;}
    public DateOnly ReleaseYear{get; init;}
}