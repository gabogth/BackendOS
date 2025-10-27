using System.Collections.Generic;
using MediatR;
using nest.core.aplicacion.general.Personas.Commands;
using nest.core.dominio.General.PersonaEntities;

namespace nest.core.aplicacion.general.PersonaUseCases.Commands
{
    public sealed record PersonaAdjuntosUseCaseModificarCommand(
        int Id,
        int EmpresaId,
        string Nombres,
        string ApellidoPaterno,
        string ApellidoMaterno,
        DateTime FechaNacimiento,
        string DocumentoIdentidad,
        string Correo,
        string Celular,
        bool Estado,
        byte SexoId,
        int DistritoId,
        byte? LicenciaConducirId,
        byte DocumentoIdentidadTipoId,
        IReadOnlyCollection<PersonaAdjuntoItemCommand>? PersonaAdjuntos = null
    ) : IRequest<Persona>, IPersonaAdjuntosUseCaseCommand;
}
