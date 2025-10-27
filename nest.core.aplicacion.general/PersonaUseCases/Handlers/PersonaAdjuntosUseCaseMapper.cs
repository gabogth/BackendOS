using System.Linq;
using nest.core.aplicacion.general.PersonaUseCases.Commands;
using nest.core.dominio.General.PersonaAdjuntoEntities;
using nest.core.dominio.General.PersonaEntities;

namespace nest.core.aplicacion.general.PersonaUseCases.Handlers
{
    internal static class PersonaAdjuntosUseCaseMapper
    {
        public static Persona ToPersona(IPersonaAdjuntosUseCaseCommand command, int? id = null)
        {
            return new Persona
            {
                Id = id ?? 0,
                EmpresaId = command.EmpresaId,
                Nombres = command.Nombres,
                ApellidoPaterno = command.ApellidoPaterno,
                ApellidoMaterno = command.ApellidoMaterno,
                FechaNacimiento = command.FechaNacimiento,
                DocumentoIdentidad = command.DocumentoIdentidad,
                Correo = command.Correo,
                Celular = command.Celular,
                Estado = command.Estado,
                SexoId = command.SexoId,
                DistritoId = command.DistritoId,
                LicenciaConducirId = command.LicenciaConducirId,
                DocumentoIdentidadTipoId = command.DocumentoIdentidadTipoId
            };
        }

        public static PersonaAdjunto[] ToAdjuntos(IPersonaAdjuntosUseCaseCommand command, Persona persona)
        {
            if (command.PersonaAdjuntos is null)
            {
                return Array.Empty<PersonaAdjunto>();
            }

            return command.PersonaAdjuntos
                .Select(adj => new PersonaAdjunto
                {
                    Id = adj.Id ?? 0,
                    EmpresaId = persona.EmpresaId,
                    PersonaId = persona.Id,
                    AdjuntoId = adj.AdjuntoId,
                    AdjuntoTipoId = adj.AdjuntoTipoId,
                    EsFotoPrincipal = adj.EsFotoPrincipal
                })
                .ToArray();
        }
    }
}
