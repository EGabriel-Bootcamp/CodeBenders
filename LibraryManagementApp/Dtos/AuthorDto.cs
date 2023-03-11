namespace LibraryManagementApp.Dtos;

public record AuthorDto
{
    public Guid Id { get; init; }
    public string FirstName{get; init;}
    public string LastName{get; init;}
    public string AvatarUrl{get; init;}
    public string PublisherName{get; init;}
    public Guid PublisherId {get; init;}
}