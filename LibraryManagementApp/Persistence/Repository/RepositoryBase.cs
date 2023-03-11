using System.Linq.Expressions;
using LibraryManagementApp.Contracts.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementApp.Persistence.Repository;

public class RepositoryBase<T>: IRepositoryBase<T> where T: class
{
    protected readonly ApplicationDbContext _context;

    public RepositoryBase(ApplicationDbContext context) =>
        _context = context;
    
    public T FindById(Guid id) =>
        _context.Set<T>().Find(id);
    
    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) => 
        !trackChanges ?
            _context.Set<T>()
                .Where(expression)
                .AsNoTracking() :
            _context.Set<T>()
                .Where(expression);

    public IQueryable<T> FindAll(bool trackChanges) =>
        !trackChanges ?
            _context.Set<T>()
                .AsNoTracking() :
            _context.Set<T>();

    public void Add(T entity) =>
        _context.Set<T>().Add(entity);

    public void AddRange(IEnumerable<T> entities) =>
        _context.Set<T>().AddRange(entities);

    public void Update(T entity) =>
        _context.Set<T>().Update(entity);

    public void Remove(T entity) => 
        _context.Set<T>().Remove(entity);

    public void RemoveRange(IEnumerable<T> entities) =>
        _context.Set<T>().RemoveRange(entities);
}