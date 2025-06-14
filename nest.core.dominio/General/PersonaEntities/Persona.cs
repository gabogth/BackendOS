using nest.core.dominio.General.DocumentoIdentidadTipoEntities;
using nest.core.dominio.General.LicenciaConducirEntities;
using nest.core.dominio.General.SexoEntities;
using nest.core.dominio.Security.Audit;
using System.ComponentModel.DataAnnotations;

namespace nest.core.dominio.General.PersonaEntities
{
    public class Persona : IAuditable, IEntity<int>
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string NombreCompleto => $"{ApellidoPaterno} {ApellidoMaterno}, {Nombres}";
        public DateTime FechaNacimiento { get; set; }
        public string DocumentoIdentidad { get; set; }
        [EmailAddress]
        public string Correo { get; set; }
        public string Celular { get; set; }
        public bool Estado { get; set; }
        public byte SexoId { get; set; }
        public byte? LicenciaConducirId { get; set; }
        public byte DocumentoIdentidadTipoId { get; set; }
        public DocumentoIdentidadTipo DocumentoIdentidadTipo { get; set; }
        public LicenciaConducir LicenciaConducir { get; set; }
        public Sexo Sexo { get; set; }
    }
}
