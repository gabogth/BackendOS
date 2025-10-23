using System;

namespace nest.core.aplicacion.general.Personas.Dtos
{
    public class PersonaCreateDto
    {
        public int EmpresaId { get; set; }
        public string Nombres { get; set; } = string.Empty;
        public string ApellidoPaterno { get; set; } = string.Empty;
        public string ApellidoMaterno { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }
        public string DocumentoIdentidad { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Celular { get; set; } = string.Empty;
        public bool Estado { get; set; }
        public byte SexoId { get; set; }
        public int DistritoId { get; set; }
        public byte? LicenciaConducirId { get; set; }
        public byte DocumentoIdentidadTipoId { get; set; }
    }
}
