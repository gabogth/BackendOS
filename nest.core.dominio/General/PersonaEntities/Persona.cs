using nest.core.dominio.General.DocumentoIdentidadTipoEntities;
using nest.core.dominio.General.LicenciaConducirEntities;
using nest.core.dominio.General.SexoEntities;
using System.ComponentModel.DataAnnotations;

namespace nest.core.dominio.General.PersonaEntities
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
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
