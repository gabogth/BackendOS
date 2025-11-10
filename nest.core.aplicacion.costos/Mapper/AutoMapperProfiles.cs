using AutoMapper;
using nest.core.aplicacion.costos.CentroCostos.Commands;
using nest.core.dominio.Costos.CentroDeCostosEntities;

namespace nest.core.aplicacion.costos.Mapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            MapAllEntities();
            CreateMap<CentroDeCostosCrearCommand, CentroDeCostos>();
            CreateMap<CentroDeCostosModificarCommand, CentroDeCostos>();
        }

        private void MapAllEntities()
        {
            CreateMap<CentroDeCostos, CentroDeCostos>()
                .ForMember(dest => dest.Padre, opt => opt.Ignore())
                .ForMember(dest => dest.Children, opt => opt.Ignore());
        }
    }
}
