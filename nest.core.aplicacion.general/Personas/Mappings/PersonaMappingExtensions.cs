using System;
using System.Collections.Generic;
using System.Linq;
using nest.core.aplicacion.general.Personas.Dtos;
using nest.core.dominio.General.PersonaEntities;

namespace nest.core.aplicacion.general.Personas.Mappings
{
    public static class PersonaMappingExtensions
    {
        public static PersonaCrearDto ToDomainDto(this PersonaCreateDto dto)
        {
            if (dto is null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            return new PersonaCrearDto
            {
                EmpresaId = dto.EmpresaId,
                Nombres = dto.Nombres,
                ApellidoPaterno = dto.ApellidoPaterno,
                ApellidoMaterno = dto.ApellidoMaterno,
                FechaNacimiento = dto.FechaNacimiento,
                DocumentoIdentidad = dto.DocumentoIdentidad,
                Correo = dto.Correo,
                Celular = dto.Celular,
                Estado = dto.Estado,
                SexoId = dto.SexoId,
                DistritoId = dto.DistritoId,
                LicenciaConducirId = dto.LicenciaConducirId,
                DocumentoIdentidadTipoId = dto.DocumentoIdentidadTipoId
            };
        }

        public static PersonaResponseDto? ToResponseDto(this Persona? persona)
            => persona is null ? null : PersonaResponseDto.FromEntity(persona);

        public static List<PersonaResponseDto> ToResponseDtoList(this IEnumerable<Persona> personas)
            => personas.Select(PersonaResponseDto.FromEntity).ToList();
    }
}
