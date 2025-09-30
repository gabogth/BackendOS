using AutoMapper;
using nest.core.dominio.Patrimonial.ActivoEntities;

namespace nest.core.infraestructura.patrimonial.Mapper
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<ActivoCrearDto, Activo>();
        }
    }
}
