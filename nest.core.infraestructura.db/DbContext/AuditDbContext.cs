using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MySqlConnector;
using nest.core.dominio.Security.Audit;
using Npgsql;
using System.Reflection;

namespace nest.core.infraestructura.db.DbContext
{
    public partial class NestDbContext
    {
        public DbSet<CorrelativoMaestro> CorrelativoMaestro { get; set; }
        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries().Where(e => e.Entity is IAuditable && e.State != EntityState.Unchanged).ToList();
            foreach (var e in entries)
            {
                var auditEntityName = $"{e.Metadata.ClrType.Name}Audit";
                var auditRow = new Dictionary<string, object?>();

                foreach (var prop in e.Properties)
                    auditRow[prop.Metadata.Name] = prop.CurrentValue;

                auditRow["FechaAuditoria"] = DateTime.UtcNow;
                auditRow["AccionAuditoria"] = e.State.ToString();
                auditRow["UsuarioAuditoria"] = usuario;
                Set<Dictionary<string, object>>(auditEntityName).Add(auditRow);
            }
            return base.SaveChanges();
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries().Where(e => e.Entity is IAuditable && e.State != EntityState.Unchanged).ToList();
            string cs = Database.GetConnectionString();
            string appName = Database.IsSqlServer()
                ? new SqlConnectionStringBuilder(cs).ApplicationName
                : Database.IsNpgsql()
                ? new NpgsqlConnectionStringBuilder(cs).ApplicationName 
                : Database.IsMySql()
                ? new MySqlConnectionStringBuilder(cs).ApplicationName
                : null;
            foreach (var e in entries)
            {
                var auditEntityName = $"{e.Metadata.ClrType.Name}Audit";
                var auditRow = new Dictionary<string, object?>();

                foreach (var prop in e.Properties)
                    auditRow[prop.Metadata.Name] = prop.CurrentValue;

                auditRow["FechaAuditoria"] = DateTime.Now;
                auditRow["AccionAuditoria"] = e.State.ToString();
                auditRow["UsuarioAuditoria"] = usuario;
                auditRow["AppVersion"] = Assembly.GetExecutingAssembly().GetName().Version?.ToString();
                auditRow["App"] = appName;
                auditRow["AssemblyName"] = Assembly.GetExecutingAssembly().GetName().Name?.ToString();
                Set<Dictionary<string, object>>(auditEntityName).Add(auditRow);
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
