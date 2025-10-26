using AutoMapper;
using nest.core.aplicacion.costos.CentroDeCostos.Commands;
using nest.core.dominio.Costos.CentroDeCostosEntities;

namespace nest.core.infraestructura.costos.Mapper
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<CentroDeCostosCrearCommand, CentroDeCostos>();
            CreateMap<CentroDeCostosModificarCommand, CentroDeCostos>();
        }
    }
}
