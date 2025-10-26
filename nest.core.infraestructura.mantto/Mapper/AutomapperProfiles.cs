using AutoMapper;
using nest.core.aplicacion.mantto.Labores.Commands;
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
            CreateMap<MantenimientoTipoCrearDto, MantenimientoTipo>();
            CreateMap<OrdenServicioCabeceraCrearDto, OrdenServicioCabecera>();
            CreateMap<OrdenServicioMantenimientoExternoCrearDto, OrdenServicioMantenimientoExterno>();
            CreateMap<OrdenServicioTipoCrearDto, OrdenServicioTipo>();
            CreateMap<OrdenTrabajoCabeceraCrearDto, OrdenTrabajoCabecera>();
            CreateMap<OrdenTrabajoDetalleCrearDto, OrdenTrabajoDetalle>();
            CreateMap<OrdenTrabajoPersonalCrearDto, OrdenTrabajoPersonal>();
            CreateMap<OrdenTrabajoDetalleActivoCrearDto, OrdenTrabajoDetalleActivo>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.OrdenTrabajoDetalleId));
        }
    }
}
