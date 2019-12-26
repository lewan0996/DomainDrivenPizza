using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shared.Domain;

namespace Shared.Infrastructure
{
    public class Repository<T, TDbContext> : IRepository<T>
        where T : AggregateRoot
        where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;

        public Repository(TDbContext dbContext, IUnitOfWork unitOfWork)
        {
            _dbContext = dbContext;
            UnitOfWork = unitOfWork;
        }
        public virtual async Task AddAsync(T item)
        {
            await _dbContext.Set<T>().AddAsync(item);
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public virtual async Task<IReadOnlyList<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public virtual void Delete(T item)
        {
            _dbContext.Set<T>().Remove(item);
        }

        public IUnitOfWork UnitOfWork { get; }
    }
}
