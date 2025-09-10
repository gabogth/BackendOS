using Microsoft.Extensions.Configuration;

namespace nest.core.aplication.auth
{
    public static class MigrationService
    {
        public static bool IsMigration()
        {
            var commandMigration = Environment.GetCommandLineArgs().FirstOrDefault(x => x == "migrations" || x == "database");
            return !string.IsNullOrWhiteSpace(commandMigration);
        }

        public static string MigrationConnection()
        {
            string connection = Environment.GetCommandLineArgs().FirstOrDefault(x => x.Contains("connection="));
            if (string.IsNullOrWhiteSpace(connection))
                throw new Exception("No se ha declarado ninguna conexion dentro de la migración\nUtilize al final del comando -- connection=connection_key");
            return connection.Substring("connection=".Length).Trim();
        }

        public static string GetEngine(IConfigurationManager configuration, string connection)
        {
            return configuration.GetValue<string>($"Connections:{connection}");
        }
    }
}
