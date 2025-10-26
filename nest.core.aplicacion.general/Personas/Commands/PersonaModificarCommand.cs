using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.General.PersonaEntities;

namespace nest.core.aplicacion.general.Personas.Commands
{
    public record PersonaModificarCommand(
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
        byte DocumentoIdentidadTipoId
    ) : IRequest<Persona>, ICommandBase;
}
