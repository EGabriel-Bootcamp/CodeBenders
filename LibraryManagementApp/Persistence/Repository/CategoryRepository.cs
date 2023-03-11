using LibraryManagementApp.Contracts.RepositoryContracts;
using LibraryManagementApp.Domain;

namespace LibraryManagementApp.Persistence.Repository;

public class CategoryRepository: RepositoryBase<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext context) : base(context)
    {
    }
}