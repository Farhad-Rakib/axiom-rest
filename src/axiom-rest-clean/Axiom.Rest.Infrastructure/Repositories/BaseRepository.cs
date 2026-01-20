using Axiom.Rest.Application.Abstractions.Repositories;
using Axiom.Rest.Domain.Common;
using Axiom.Rest.Infrastructure.Persistence.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Axiom.Rest.Infrastructure.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context) => _context = context;

    public async Task<T?> GetByIdAsync(long id) =>
        await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);

    public async Task<IReadOnlyList<T>> GetAllAsync() =>
        await _context.Set<T>().ToListAsync();

    public async Task AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }
}
