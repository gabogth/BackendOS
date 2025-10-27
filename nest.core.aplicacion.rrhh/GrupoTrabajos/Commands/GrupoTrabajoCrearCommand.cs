using MediatR;
using nest.core.dominio.RRHH.GrupoTrabajoEntities;

namespace nest.core.aplicacion.rrhh.GrupoTrabajos.Commands
{
    public record GrupoTrabajoCrearCommand(
        int EmpresaId,
        string Nombre,
        string NombreCorto,
        bool Estado,
        IReadOnlyCollection<GrupoTrabajoPersonaCommand> Personas
    ) : IRequest<GrupoTrabajo>, IGrupoTrabajoGenericCommand;
}
