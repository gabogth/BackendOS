using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using nest.core.dominio.Security.Audit;

namespace nest.core.infraestructura.db.DbContext
{
    public partial class NestDbContext
    {
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<CorrelativoMaestro> CorrelativoMaestro { get; set; }
        public override int SaveChanges()
        {
            List<AuditEntry> auditEntries = OnBeforeSaveChanges();
            int result = base.SaveChanges();
            OnAfterSaveChanges(auditEntries);
            return result;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            List<AuditEntry> auditEntries = OnBeforeSaveChanges();
            int result = await base.SaveChangesAsync(cancellationToken);
            await OnAfterSaveChangesAsync(auditEntries);
            return result;
        }

        private List<AuditEntry> OnBeforeSaveChanges()
        {
            ChangeTracker.DetectChanges();
            var auditEntries = new List<AuditEntry>();
            IEnumerable<EntityEntry> entries = ChangeTracker.Entries();

            foreach (EntityEntry entry in entries)
            {
                if (entry.Entity is AuditLog || entry.Entity is CorrelativoMaestro || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                    continue;

                var entityType = entry.Entity.GetType();
                var entityTypeModel = ChangeTracker.Context.Model.FindEntityType(entityType);
                var schema = entityTypeModel.GetSchema() ?? "dbo";
                var tableName = entityTypeModel.GetTableName();

                AuditEntry auditEntry = new AuditEntry(entry)
                {
                    Tabla = $"{schema}.{tableName}",
                    Accion = entry.State.ToString(),
                    Fecha = DateTime.Now,
                    Usuario = this.usuario
                };

                foreach (PropertyEntry property in entry.Properties)
                {
                    string propertyName = property.Metadata.Name;
                    if (propertyName == "Id")
                        auditEntry.EntidadId = property.CurrentValue?.ToString();
                    if (entry.State == EntityState.Added)
                        auditEntry.NewValues[propertyName] = property.CurrentValue;
                    else if (entry.State == EntityState.Deleted)
                        auditEntry.OldValues[propertyName] = property.OriginalValue;
                    else if (entry.State == EntityState.Modified)
                        if (property.IsModified)
                        {
                            auditEntry.OldValues[propertyName] = property.OriginalValue;
                            auditEntry.NewValues[propertyName] = property.CurrentValue;
                        }
                }
                auditEntries.Add(auditEntry);
            }
            return auditEntries;
        }

        private void OnAfterSaveChanges(List<AuditEntry> auditEntries)
        {
            if (auditEntries == null || auditEntries.Count == 0)
                return;

            foreach (var auditEntry in auditEntries)
                AuditLogs.Add(auditEntry.ToAuditLog());

            SaveChanges();
        }

        private async Task OnAfterSaveChangesAsync(List<AuditEntry> auditEntries)
        {
            if (auditEntries == null || auditEntries.Count == 0)
                return;

            foreach (var auditEntry in auditEntries)
                AuditLogs.Add(auditEntry.ToAuditLog());

            await SaveChangesAsync();
        }
    }
}
