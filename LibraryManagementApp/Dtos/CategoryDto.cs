namespace LibraryManagementApp.Dtos;

public record CategoryDto
{
    public Guid Id { get; init; }
    public string Name{get; set;}
    public string Description{get; set;}
}