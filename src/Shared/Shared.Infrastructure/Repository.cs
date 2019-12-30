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
        protected readonly TDbContext DbContext;

        public Repository(TDbContext dbContext, IUnitOfWork unitOfWork)
        {
            DbContext = dbContext;
            UnitOfWork = unitOfWork;
        }
        public virtual async Task AddAsync(T item)
        {
            await DbContext.Set<T>().AddAsync(item);
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await DbContext.Set<T>().FindAsync(id);
        }

        public virtual async Task<IReadOnlyList<T>> GetAll()
        {
            return await DbContext.Set<T>().ToListAsync();
        }

        public virtual void Delete(T item)
        {
            DbContext.Set<T>().Remove(item);
        }

        public IUnitOfWork UnitOfWork { get; }
    }
}
