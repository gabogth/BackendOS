using AutoMapper;
using nest.core.dominio.Legal.ContratoTipoEntities;

namespace nest.core.infraestructura.legal.Mapper
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<ContratoTipoCrearDto, ContratoTipo>();
        }
    }
}
