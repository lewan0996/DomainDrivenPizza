using System.Threading.Tasks;
using Domain.SharedKernel;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Shared
{
    public class Repository<T> : IRepository<T> where T : AggregateRoot
    {
        private readonly DbContext _dbContext;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Add(T item)
        {
            await _dbContext.Set<T>().AddAsync(item);
        }

        public async Task<T> GetById(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }
    }
}
