using LibraryManagementApp.Contracts.RepositoryContracts;
using LibraryManagementApp.Domain;

namespace LibraryManagementApp.Persistence.Repository;

public class AuthorRepository: RepositoryBase<Author>, IAuthorRepository
{
    public AuthorRepository(ApplicationDbContext context) : base(context)
    {
    }
}