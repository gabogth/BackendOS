using AutoMapper;
using nest.core.dominio.Mantto.LaborEntities;
using nest.core.dominio.Mantto.MantenimientoTipoEntities;
using nest.core.dominio.Mantto.OrdenServicioTipoEntities;

namespace nest.core.infraestructura.mantto.Mapper
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<LaborCrearDto, Labor>();
            CreateMap<MantenimientoTipoCrearDto, MantenimientoTipo>();
            CreateMap<OrdenServicioTipoCrearDto, OrdenServicioTipo>();
        }
    }
}
