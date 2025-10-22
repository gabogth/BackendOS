using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.General.AdjuntoProviderEntities
{
    public class AdjuntoConfigProvider: IEntity<AdjuntoConfigProviderModuloEnum>, IAuditable
    {
        public AdjuntoConfigProviderModuloEnum Id { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public AdjuntoProviderEnum AdjuntoProvider { get; set; }
        public string Container { get; set; }
        public string MainPath { get; set; }
        public bool Activo { get; set; }
    }

    public enum AdjuntoProviderEnum : byte
    {
        Local = 1,
        AzureBlobStorage = 2,
        AmazonS3 = 3,
        GoogleCloudStorage = 4
    }

    public enum AdjuntoConfigProviderModuloEnum : int
    {
        PersonalFoto = 1
    }
}
