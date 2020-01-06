using System;
using Microsoft.EntityFrameworkCore.Storage;
using Shared.Domain;

namespace Shared.Infrastructure
{
    public class DbContextTransactionAdapter : ITransaction
    {
        private readonly IDbContextTransaction _transaction;

        public DbContextTransactionAdapter(IDbContextTransaction transaction)
        {
            _transaction = transaction ?? throw new ArgumentNullException(nameof(transaction));
        }
        public void Dispose()
        {
            _transaction.Dispose();
        }

        public Guid Id => _transaction.TransactionId;
        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }
    }
}
