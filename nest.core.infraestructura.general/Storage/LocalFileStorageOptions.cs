namespace nest.core.infraestructura.general.Storage
{
    public class LocalFileStorageOptions
    {
        /// <summary>
        /// Root directory where adjuntos will be stored. Can be absolute or relative to the application base directory.
        /// </summary>
        public string RootPath { get; set; }

        /// <summary>
        /// Default container name used when the config repository does not specify one.
        /// </summary>
        public string DefaultContainerName { get; set; }
    }
}
