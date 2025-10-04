using AutoMapper;
using nest.core.dominio.Patrimonial.ActivoEntities;
using nest.core.dominio.Patrimonial.UbicacionActivoEntities;
using nest.core.dominio.Patrimonial.UbicacionTecnicaEntities;

namespace nest.core.infraestructura.patrimonial.Mapper
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<ActivoCrearDto, Activo>();
            CreateMap<UbicacionActivoCrearDto, UbicacionActivo>();
            CreateMap<UbicacionTecnicaCrearDto, UbicacionTecnica>();
        }
    }
}
