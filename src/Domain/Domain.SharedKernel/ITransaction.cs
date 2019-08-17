using System;

namespace Domain.SharedKernel
{
    public interface ITransaction : IDisposable
    {
        Guid Id { get; }
        void Commit();
        void Rollback();
    }
}
