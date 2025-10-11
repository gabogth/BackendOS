using Microsoft.EntityFrameworkCore.Storage;
using nest.core.dominio.Transaccional;
using nest.core.infraestructura.db.DbContext;

namespace nest.core.infraestructura.db.Transaccional
{
    public class EfUnitOfWork: IUnitOfWork
    {
        private readonly NestDbContext context;
        private IDbContextTransaction dbContextTransaction;
        public EfUnitOfWork(NestDbContext context)
        {
            this.context = context;
        }
        public IDbContextTransaction BeginTransaction()
        {
            this.dbContextTransaction = context.Database.BeginTransaction();
            return this.dbContextTransaction;
        }
        public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            this.dbContextTransaction = await context.Database.BeginTransactionAsync(cancellationToken);
            return this.dbContextTransaction;
        }
        public void Commit()
        {
            context.SaveChanges();
            if (dbContextTransaction != null)
                dbContextTransaction.Commit();
        }
        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            await context.SaveChangesAsync(cancellationToken);
            if(dbContextTransaction != null)
                await dbContextTransaction.CommitAsync(cancellationToken);
        }
        public void Rollback()
        {
            if (dbContextTransaction != null)
                dbContextTransaction.Rollback();
        }
        public async Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            if (dbContextTransaction != null)
                await dbContextTransaction.RollbackAsync(cancellationToken);
        }
        public void Dispose()
        {
            if (dbContextTransaction != null)
                try { dbContextTransaction.Dispose(); } catch { }
            try { context.Dispose(); } catch { }
            
        }
        public async ValueTask DisposeAsync()
        {
            if (dbContextTransaction != null)
                try { await dbContextTransaction.DisposeAsync(); } catch { }
            try { await context.DisposeAsync(); } catch { }
        }
    }
}
