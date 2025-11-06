using AutoMapper;
using nest.core.aplicacion.mantto.Labores.Commands;
using nest.core.aplicacion.mantto.MantenimientoTipos.Commands;
using nest.core.aplicacion.mantto.OrdenServicioCabeceras.Commands;
using nest.core.aplicacion.mantto.OrdenServicioMantenimientoExternos.Commands;
using nest.core.aplicacion.mantto.OrdenServicioTipos.Commands;
using nest.core.aplicacion.mantto.OrdenTrabajoCabeceras.Commands;
using nest.core.aplicacion.mantto.OrdenTrabajoDetalleActivos.Commands;
using nest.core.aplicacion.mantto.OrdenTrabajoDetalles.Commands;
using nest.core.aplicacion.mantto.OrdenTrabajoPersonales.Commands;
using nest.core.aplicacion.mantto.OrdenTrabajoHorarios.Commands;
using nest.core.dominio.Mantto.LaborEntities;
using nest.core.dominio.Mantto.MantenimientoTipoEntities;
using nest.core.dominio.Mantto.OrdenServicioCabeceraEntities;
using nest.core.dominio.Mantto.OrdenServicioMantenimientoExternoEntities;
using nest.core.dominio.Mantto.OrdenServicioTipoEntities;
using nest.core.dominio.Mantto.OrdenTrabajoCabeceraEntities;
using nest.core.dominio.Mantto.OrdenTrabajoDetalleActivoEntities;
using nest.core.dominio.Mantto.OrdenTrabajoDetalleEntities;
using nest.core.dominio.Mantto.OrdenTrabajoPersonalEntities;
using nest.core.dominio.Mantto.OrdenTrabajoHorarioEntities;

namespace nest.core.aplicacion.mantto.Mapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<LaborCrearCommand, Labor>();
            CreateMap<LaborModificarCommand, Labor>();
            CreateMap<MantenimientoTipoCrearCommand, MantenimientoTipo>();
            CreateMap<MantenimientoTipoModificarCommand, MantenimientoTipo>();
            CreateMap<OrdenServicioCabeceraCrearCommand, OrdenServicioCabecera>();
            CreateMap<OrdenServicioCabeceraModificarCommand, OrdenServicioCabecera>();
            CreateMap<OrdenServicioMantenimientoExternoCrearCommand, OrdenServicioMantenimientoExterno>();
            CreateMap<OrdenServicioMantenimientoExternoModificarCommand, OrdenServicioMantenimientoExterno>();
            CreateMap<OrdenServicioTipoCrearCommand, OrdenServicioTipo>();
            CreateMap<OrdenServicioTipoModificarCommand, OrdenServicioTipo>();
            CreateMap<OrdenTrabajoCabeceraCrearCommand, OrdenTrabajoCabecera>();
            CreateMap<OrdenTrabajoCabeceraModificarCommand, OrdenTrabajoCabecera>();
            CreateMap<OrdenTrabajoDetalleActivoCrearCommand, OrdenTrabajoDetalleActivo>();
            CreateMap<OrdenTrabajoDetalleActivoModificarCommand, OrdenTrabajoDetalleActivo>();
            CreateMap<OrdenTrabajoDetalleCrearCommand, OrdenTrabajoDetalle>();
            CreateMap<OrdenTrabajoDetalleModificarCommand, OrdenTrabajoDetalle>();
            CreateMap<OrdenTrabajoPersonalCrearCommand, OrdenTrabajoPersonal>();
            CreateMap<OrdenTrabajoPersonalModificarCommand, OrdenTrabajoPersonal>();
            CreateMap<OrdenTrabajoHorarioCrearCommand, OrdenTrabajoHorario>();
            CreateMap<OrdenTrabajoHorarioModificarCommand, OrdenTrabajoHorario>();
        }
    }
}
