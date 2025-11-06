using MediatR;
using nest.core.aplicacion.mantto.OrdenTrabajoDetalleActivos.Commands;
using nest.core.aplicacion.mantto.OrdenTrabajoDetalles.Commands;
using nest.core.dominio.Mantto.OrdenTrabajoCabeceraEntities;
using nest.core.dominio.Mantto.OrdenTrabajoDetalleEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajo.Commands
{
    public record OTMantenimientoExternoDetalleCrearCommand(
        int EmpresaId, 
        long OrdenTrabajoCabeceraId, 
        long UbicacionTecnicaId, 
        int LaborId, 
        int HorasProyectadas, 
        int HorasEjecutadas, 
        string? Descripcion, 
        OrdenTrabajoDetalleEstado Estado,
        OrdenTrabajoDetalleActivoCrearCommand Activo
    ) : OrdenTrabajoDetalleCrearCommand(
        EmpresaId, 
        OrdenTrabajoCabeceraId, 
        UbicacionTecnicaId, 
        LaborId, 
        HorasProyectadas, 
        HorasEjecutadas, 
        Descripcion, 
        Estado
    ), IRequest<OrdenTrabajoCabecera>;
}
