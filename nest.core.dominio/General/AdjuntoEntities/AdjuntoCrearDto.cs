namespace nest.core.dominio.General.AdjuntoEntities
{
    public class AdjuntoCrearDto
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public long Size { get; set; }
        public AdjuntoProviderEnum AdjuntoProvider { get; set; }
        public string Container { get; set; }
        public string FullPath { get; set; }
        public string NombreGenerado { get; set; }
    }
}
