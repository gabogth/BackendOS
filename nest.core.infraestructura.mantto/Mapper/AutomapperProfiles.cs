using AutoMapper;
using nest.core.dominio.Mantto.LaborEntities;
using nest.core.dominio.Mantto.MantenimientoTipoEntities;
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
            CreateMap<LaborCrearDto, Labor>();
            CreateMap<MantenimientoTipoCrearDto, MantenimientoTipo>();
            CreateMap<OrdenServicioTipoCrearDto, OrdenServicioTipo>();
            CreateMap<OrdenTrabajoCabeceraCrearDto, OrdenTrabajoCabecera>();
            CreateMap<OrdenTrabajoDetalleCrearDto, OrdenTrabajoDetalle>();
            CreateMap<OrdenTrabajoPersonalCrearDto, OrdenTrabajoPersonal>();
            CreateMap<OrdenTrabajoDetalleActivoCrearDto, OrdenTrabajoDetalleActivo>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.OrdenTrabajoDetalleId));
        }
    }
}
