﻿using System.Collections.Generic;
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
    }
}
