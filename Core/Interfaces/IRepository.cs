using System.Linq.Expressions;
namespace Core.Interfaces{
public interface IRepository where T:class{
Task GetByIdAsync(int id);
Task> GetAllAsync();
Task> Where(Expression> predicate);
Task AddAsync(T entity);
Task UpdateAsync(T entity);
Task DeleteAsync(T entity);
}
}