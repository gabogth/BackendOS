using AutoMapper;
using nest.core.aplicacion.legal.ContratoTipos.Commands;
using nest.core.dominio.Legal.ContratoTipoEntities;

namespace nest.core.aplicacion.legal.Mapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            MapAllEntities();
            CreateMap<ContratoTipoCrearCommand, ContratoTipo>();
            CreateMap<ContratoTipoModificarCommand, ContratoTipo>();
        }

        private void MapAllEntities()
        {
            CreateMap<ContratoTipo, ContratoTipo>();
        }
    }
}
