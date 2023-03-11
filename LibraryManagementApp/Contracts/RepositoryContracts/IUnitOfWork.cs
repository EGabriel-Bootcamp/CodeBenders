namespace LibraryManagementApp.Contracts.RepositoryContracts;

public interface IUnitOfWork: IDisposable
{
    IAuthorRepository Authors { get; }
    IBookRepository Books { get; }
    IPublisherRepository Publishers { get; }
    ICategoryRepository Categories { get; }

    int Complete();
}