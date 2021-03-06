﻿using System;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Domain;

namespace Shared.Infrastructure
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly DbContext[] _contexts;
        private ITransaction _currentTransaction;
        private IMediator _mediator;

        public EFUnitOfWork(IMediator mediator, params DbContext[] contexts)
        {
            if (contexts == null || !contexts.Any())
            {
                throw new ArgumentException(nameof(contexts));
            }

            _mediator = mediator;
            _contexts = contexts;
        }
        public async Task<ITransaction> BeginTransactionAsync()
        {
            if (HasActiveTransaction) return _currentTransaction;

            _currentTransaction =
                new DbContextTransactionAdapter(await _contexts[0].Database.BeginTransactionAsync());
            return _currentTransaction;
        }

        public async Task<int> SaveEntitiesAsync()
        {
            await DispatchDomainEventsAsync();
            var saveChangesTasks = _contexts.Select(c => c.SaveChangesAsync());
            var rowsAffectedPerTask = await Task.WhenAll(saveChangesTasks);

            return rowsAffectedPerTask.Sum();
        }

        public async Task CommitTransactionAsync(ITransaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            if (transaction != _currentTransaction) throw new InvalidOperationException($"Transaction {transaction.Id} is not current");
            try
            {
                await SaveEntitiesAsync();
                _currentTransaction.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public bool HasActiveTransaction => _currentTransaction != null;

        private async Task DispatchDomainEventsAsync()
        {
            var domainEventTasks = _contexts.Select(c => _mediator.DispatchDomainEventsAsync(c));
            await Task.WhenAll(domainEventTasks);
        }
    }
}

