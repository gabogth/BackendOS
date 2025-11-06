using MediatR;
using nest.core.aplicacion.mantto.OrdenServicioCabeceras.Commands;
using nest.core.aplicacion.mantto.OrdenServicioMantenimientoExternos.Commands;
using nest.core.dominio.Mantto.OrdenServicioCabeceraEntities;

namespace nest.core.aplicacion.mantto.OrdenServicio.Commands
{
    public sealed record OSMantenimientoExternoCrearCommand (
        OrdenServicioCabeceraCrearCommand Cabecera,
        OrdenServicioMantenimientoExternoCrearCommand Externo
    ) : IRequest<OrdenServicioCabecera>, IOSMantenimientoExternoGenericCommand;
}
