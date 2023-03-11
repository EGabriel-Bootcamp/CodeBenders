using LibraryManagementApp.Contracts.RepositoryContracts;
using LibraryManagementApp.Domain;

namespace LibraryManagementApp.Persistence.Repository;

public class BookRepository: RepositoryBase<Book>, IBookRepository
{
    public BookRepository(ApplicationDbContext context) : base(context)
    {
    }
}