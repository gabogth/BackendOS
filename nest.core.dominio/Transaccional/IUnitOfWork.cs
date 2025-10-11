using Microsoft.EntityFrameworkCore.Storage;

namespace nest.core.dominio.Transaccional
{
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task CommitAsync(CancellationToken cancellationToken = default);
        Task RollbackAsync(CancellationToken cancellationToken = default);
        IDbContextTransaction BeginTransaction();
        void Commit();
        void Rollback();
    }
}
