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
            MakeAudit();
            return base.SaveChanges();
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            MakeAudit();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void MakeAudit()
        {
            var entries = ChangeTracker.Entries().Where(e => e.Entity is IAuditable && e.State != EntityState.Unchanged).ToList();
            string appName = GetAppName();
            foreach (var e in entries)
            {
                string auditEntityName = string.Empty;
                Dictionary<string, object?> entry = GenerateEntityParams(e, appName, ref auditEntityName);
                Set<Dictionary<string, object>>(auditEntityName).Add(entry);
            }
        }

        private Dictionary<string, object?> GenerateEntityParams(EntityEntry entry, string appName, ref string auditEntityName)
        {
            auditEntityName = $"{entry.Metadata.ClrType.Name}Audit";
            var auditRow = new Dictionary<string, object?>();

            foreach (var prop in entry.Properties)
                auditRow[prop.Metadata.Name] = prop.CurrentValue;

            auditRow["AuditFecha"] = DateTime.Now;
            auditRow["AuditAccion"] = entry.State.ToString();
            auditRow["AuditUsuario"] = usuario;
            auditRow["AuditApp"] = appName;
            auditRow["AuditAppVersion"] = Assembly.GetExecutingAssembly().GetName().Version?.ToString();
            auditRow["AuditAssemblyName"] = Assembly.GetExecutingAssembly().GetName().Name?.ToString();
            auditRow["AuditRequestId"] = requestParameters.RequestId;
            auditRow["AuditPath"] = requestParameters.Path;
            auditRow["AuditMethod"] = requestParameters.Method;
            auditRow["AuditIpRemoteOrigin"] = requestParameters.IpRemoteOrigin;
            auditRow["AuditUserAgent"] = requestParameters.UserAgent;
            auditRow["AuditCurrentCulture"] = requestParameters.CurrentCulture;
            auditRow["AuditContentType"] = requestParameters.ContentType;
            auditRow["AuditIsHttps"] = requestParameters.IsHttps;
            auditRow["AuditHost"] = requestParameters.Host;
            auditRow["AuditProtocol"] = requestParameters.Protocol;
            auditRow["AuditQueryString"] = requestParameters.QueryString;
            auditRow["AuditAcceptLanguage"] = requestParameters.AcceptLanguage;
            auditRow["AuditOrigin"] = requestParameters.Origin;
            auditRow["AuditReferer"] = requestParameters.Referer;
            auditRow["AuditPlatform"] = requestParameters.Platform;
            auditRow["AuditUa"] = requestParameters.Ua;

            return auditRow;
        }

        private string GetAppName()
        {
            string cs = Database.GetConnectionString();
            return Database.IsSqlServer()
                ? new SqlConnectionStringBuilder(cs).ApplicationName
                : Database.IsNpgsql()
                ? new NpgsqlConnectionStringBuilder(cs).ApplicationName
                : Database.IsMySql()
                ? new MySqlConnectionStringBuilder(cs).ApplicationName
                : null;
        }
    }
}
