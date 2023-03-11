namespace LibraryManagementApp.Dtos;

public record PublisherDto
{
    public Guid Id { get; init; }
    public string Name{get; init;}
    public string LogoUrl{get; init;}
    public int? TotalAuthors { get; init; }
    public int? TotalBooks { get; init; }
}