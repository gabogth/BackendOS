using AutoMapper;
using nest.core.aplicacion.mantto.Labores.Commands;
using nest.core.aplicacion.mantto.MantenimientoTipos.Commands;
using nest.core.aplicacion.mantto.OrdenServicioCabeceras.Commands;
using nest.core.aplicacion.mantto.OrdenServicioMantenimientoExternos.Commands;
using nest.core.aplicacion.mantto.OrdenServicioTipos.Commands;
using nest.core.aplicacion.mantto.OrdenTrabajoCabeceras.Commands;
using nest.core.dominio.Mantto.LaborEntities;
using nest.core.dominio.Mantto.MantenimientoTipoEntities;
using nest.core.dominio.Mantto.OrdenServicioCabeceraEntities;
using nest.core.dominio.Mantto.OrdenServicioMantenimientoExternoEntities;
using nest.core.dominio.Mantto.OrdenServicioTipoEntities;
using nest.core.dominio.Mantto.OrdenTrabajoCabeceraEntities;
using nest.core.dominio.Mantto.OrdenTrabajoDetalleActivoEntities;
using nest.core.dominio.Mantto.OrdenTrabajoDetalleEntities;
using nest.core.dominio.Mantto.OrdenTrabajoPersonalEntities;

namespace nest.core.infraestructura.mantto.Mapper
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<LaborCrearCommand, Labor>();
            CreateMap<LaborModificarCommand, Labor>();
            CreateMap<MantenimientoTipoCrearCommand, MantenimientoTipo>();
            CreateMap<MantenimientoTipoModificarCommand, MantenimientoTipo>();
            CreateMap<OrdenServicioCabeceraCrearDto, OrdenServicioCabecera>();
            CreateMap<OrdenServicioCabeceraCrearCommand, OrdenServicioCabecera>();
            CreateMap<OrdenServicioCabeceraModificarCommand, OrdenServicioCabecera>();
            CreateMap<OrdenServicioMantenimientoExternoCrearDto, OrdenServicioMantenimientoExterno>();
            CreateMap<OrdenServicioMantenimientoExternoCrearCommand, OrdenServicioMantenimientoExterno>();
            CreateMap<OrdenServicioMantenimientoExternoModificarCommand, OrdenServicioMantenimientoExterno>();
            CreateMap<OrdenServicioTipoCrearCommand, OrdenServicioTipo>();
            CreateMap<OrdenServicioTipoModificarCommand, OrdenServicioTipo>();
            CreateMap<OrdenTrabajoCabeceraCrearDto, OrdenTrabajoCabecera>();
            CreateMap<OrdenTrabajoCabeceraCrearCommand, OrdenTrabajoCabecera>();
            CreateMap<OrdenTrabajoCabeceraModificarCommand, OrdenTrabajoCabecera>();
            CreateMap<OrdenTrabajoDetalleCrearDto, OrdenTrabajoDetalle>();
            CreateMap<OrdenTrabajoPersonalCrearDto, OrdenTrabajoPersonal>();
            CreateMap<OrdenTrabajoDetalleActivoCrearDto, OrdenTrabajoDetalleActivo>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.OrdenTrabajoDetalleId));
        }
    }
}
