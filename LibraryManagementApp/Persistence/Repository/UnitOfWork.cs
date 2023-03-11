using LibraryManagementApp.Contracts.RepositoryContracts;

namespace LibraryManagementApp.Persistence.Repository;

public class UnitOfWork: IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        Authors = new AuthorRepository(_context);
        Books = new BookRepository(_context);
        Publishers = new PublisherRepository(_context);
        Categories = new CategoryRepository(_context);
    }

    public IAuthorRepository Authors { get; private set; }
    public IBookRepository Books { get; private set; }
    public IPublisherRepository Publishers { get; private set; }
    public ICategoryRepository Categories { get; private set; }

    public int Complete() =>
        _context.SaveChanges();

    public void Dispose() =>
        _context.Dispose();
}