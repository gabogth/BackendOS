using System;
using nest.core.dominio.General.PersonaEntities;

namespace nest.core.aplicacion.general.Personas.Dtos
{
    public class PersonaResponseDto
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public string Nombres { get; set; } = string.Empty;
        public string ApellidoPaterno { get; set; } = string.Empty;
        public string ApellidoMaterno { get; set; } = string.Empty;
        public string NombreCompleto { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }
        public string DocumentoIdentidad { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Celular { get; set; } = string.Empty;
        public bool Estado { get; set; }
        public byte SexoId { get; set; }
        public int DistritoId { get; set; }
        public byte? LicenciaConducirId { get; set; }
        public byte DocumentoIdentidadTipoId { get; set; }

        public static PersonaResponseDto FromEntity(Persona persona)
        {
            if (persona is null)
            {
                throw new ArgumentNullException(nameof(persona));
            }

            return new PersonaResponseDto
            {
                Id = persona.Id,
                EmpresaId = persona.EmpresaId,
                Nombres = persona.Nombres,
                ApellidoPaterno = persona.ApellidoPaterno,
                ApellidoMaterno = persona.ApellidoMaterno,
                NombreCompleto = persona.NombreCompleto,
                FechaNacimiento = persona.FechaNacimiento,
                DocumentoIdentidad = persona.DocumentoIdentidad,
                Correo = persona.Correo,
                Celular = persona.Celular,
                Estado = persona.Estado,
                SexoId = persona.SexoId,
                DistritoId = persona.DistritoId,
                LicenciaConducirId = persona.LicenciaConducirId,
                DocumentoIdentidadTipoId = persona.DocumentoIdentidadTipoId
            };
        }
    }
}
