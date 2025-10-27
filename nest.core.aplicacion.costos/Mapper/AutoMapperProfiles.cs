using AutoMapper;
using nest.core.aplicacion.costos.CentroDeCostos.Commands;
using nest.core.dominio.Costos.CentroDeCostosEntities;

namespace nest.core.aplicacion.costos.Mapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CentroDeCostosCrearCommand, CentroDeCostos>();
            CreateMap<CentroDeCostosModificarCommand, CentroDeCostos>();
        }
    }
}
