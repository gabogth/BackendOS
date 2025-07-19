using AutoMapper;
using nest.core.dominio.Costos.CentroDeCostosEntities;

namespace nest.core.infraestructura.costos.Mapper
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<CentroDeCostosCrearDto, CentroDeCostos>();
        }
    }
}
