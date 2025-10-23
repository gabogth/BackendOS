using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.General.AdjuntoTipoEntities
{
    public class AdjuntoTipo : IEntity<AdjuntoTipoEnum>, IAuditable
    {
        public AdjuntoTipoEnum Id { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public bool Activo { get; set; }
    }

    public enum AdjuntoTipoEnum : int
    {
        Foto = 1,
        DocumentoIdentidad = 2,
        LicenciaConducir = 3,
        Cv = 4,
        Contrato = 5,
        Habilitacion = 6,
        Otro = 99
    }
}
