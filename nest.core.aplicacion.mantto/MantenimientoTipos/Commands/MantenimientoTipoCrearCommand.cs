using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Mantto.MantenimientoTipoEntities;

namespace nest.core.aplicacion.mantto.MantenimientoTipos.Commands
{
    public sealed record MantenimientoTipoCrearCommand(
        string Nombre,
        string NombreCorto,
        bool Activo
    ) : IRequest<MantenimientoTipo>, IMantenimientoTipoGenericCommand;
}
