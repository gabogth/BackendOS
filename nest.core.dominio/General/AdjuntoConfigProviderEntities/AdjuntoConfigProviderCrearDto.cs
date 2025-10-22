namespace nest.core.dominio.General.AdjuntoProviderEntities
{
    public class AdjuntoConfigProviderCrearDto
    {
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public AdjuntoProviderEnum AdjuntoProvider { get; set; }
        public string Container { get; set; }
        public string MainPath { get; set; }
        public bool Activo { get; set; }
    }
}
