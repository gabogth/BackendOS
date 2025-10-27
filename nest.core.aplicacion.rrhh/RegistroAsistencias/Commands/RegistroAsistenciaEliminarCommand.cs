using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.rrhh.RegistroAsistencias.Commands
{
    public record RegistroAsistenciaEliminarCommand(long Id) : IRequest<bool>, ICommandBase;
}
