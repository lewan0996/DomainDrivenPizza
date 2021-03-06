﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shared.Domain
{
    public interface IRepository<T> where T: AggregateRoot
    {
        Task AddAsync(T item);
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAll();
        void Delete(T item);
        IUnitOfWork UnitOfWork { get; }
    }
}
