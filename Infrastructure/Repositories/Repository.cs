using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace Infrastructure.Repositories{
public class Repository:IRepository where T:class{
protected readonly AppDbContext _context;
private readonly DbSet _dbSet;
public Repository(AppDbContext context){_context=context;_dbSet=context.Set();}
public async Task AddAsync(T entity)=>await _dbSet.AddAsync(entity);
public async Task DeleteAsync(T entity){_dbSet.Remove(entity);await Task.CompletedTask;}
public async Task> GetAllAsync()=>await _dbSet.ToListAsync();
public async Task GetByIdAsync(int id)=>await _dbSet.FindAsync(id);
public async Task> Where(Expression> predicate)=>await _dbSet.Where(predicate).ToListAsync();
public async Task UpdateAsync(T entity){_dbSet.Update(entity);await Task.CompletedTask;}
}
}