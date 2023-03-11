using LibraryManagementApp.Contracts.RepositoryContracts;
using LibraryManagementApp.Domain;

namespace LibraryManagementApp.Persistence.Repository;

public class PublisherRepository: RepositoryBase<Publisher>, IPublisherRepository
{
    public PublisherRepository(ApplicationDbContext context) : base(context)
    {
    }
}