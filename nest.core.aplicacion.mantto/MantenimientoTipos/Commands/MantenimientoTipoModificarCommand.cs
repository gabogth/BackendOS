using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Mantto.MantenimientoTipoEntities;

namespace nest.core.aplicacion.mantto.MantenimientoTipos.Commands
{
    public sealed record MantenimientoTipoModificarCommand(
        short Id,
        string Nombre,
        string NombreCorto,
        bool Activo
    ) : IRequest<MantenimientoTipo>, ICommandBase;
}
