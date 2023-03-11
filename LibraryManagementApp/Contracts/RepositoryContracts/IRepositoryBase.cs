using System.Linq.Expressions;

namespace LibraryManagementApp.Contracts.RepositoryContracts;

public interface IRepositoryBase<T> where T: class
{
    T FindById(Guid id);
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
    IQueryable<T> FindAll(bool trackChanges);
    void Add(T entity);
    void AddRange(IEnumerable<T> entities);
    void Update(T entity);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
}