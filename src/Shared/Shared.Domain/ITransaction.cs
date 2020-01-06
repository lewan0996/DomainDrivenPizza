using System;

namespace Shared.Domain
{
    public interface ITransaction : IDisposable
    {
        Guid Id { get; }
        void Commit();
        void Rollback();
    }
}
