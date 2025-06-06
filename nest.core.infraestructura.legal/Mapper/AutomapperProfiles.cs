using AutoMapper;
using nest.core.dominio.Legal.ContratoTipoEntities;
using nest.core.dominio.Legal.ContratoCabeceraEntities;
using nest.core.dominio.Legal.ContratoDetalleEntities;
using nest.core.dominio.Legal.ContratoPersonalEntities;

namespace nest.core.infraestructura.legal.Mapper
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<ContratoTipoCrearDto, ContratoTipo>();
            CreateMap<ContratoCabeceraCrearDto, ContratoCabecera>();
            CreateMap<ContratoDetalleCrearDto, ContratoDetalle>();
            CreateMap<ContratoPersonalCrearDto, ContratoPersonal>();
        }
    }
}
